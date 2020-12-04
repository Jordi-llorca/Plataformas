using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCombat : MonoBehaviour
{
    public GameObject pisotonEffect;
    public GameObject pisotonEffect2;
    public GameObject player;
    public float pisotonTime = 1f;

    public float damagePisoton;

    public float timeToSpecialAttack = 10f;
    float timer = 10f;

    public GameObject lights;
    public float lightsTime = 5f;
    public float velocityIncrement = 3f;

    public GameObject nubeGas;
    public float velocityDecrement = 3f;
    public float nubeGasTime = 5f;

    public Animator animator;

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = timeToSpecialAttack;
            animator.SetTrigger("AttaqueEspecial");
            FindObjectOfType<AudioManager>().Play("SteamRelease");
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0: StartCoroutine(Pisoton()); break;
                case 1: StartCoroutine(NubeCegante()); break;
                case 2: StartCoroutine(NubeVeneno()); break;
            }
            
        }
    }
    IEnumerator Pisoton()
    {
        Instantiate(pisotonEffect, transform.position, Quaternion.identity);
        GetComponent<chasePlayer>().enabled = false;
        yield return new WaitForSeconds(pisotonTime);
        Instantiate(pisotonEffect2, transform.position, Quaternion.identity);
        if (player.GetComponent<playerMovment>().isGrounded())
        {
            player.GetComponent<VidaPlayer>().QuitarVida(damagePisoton);
        }
        GetComponent<chasePlayer>().enabled = true;
    }

    IEnumerator NubeCegante()
    {
        lights.SetActive(false);
        timer += lightsTime;
        GetComponent<chasePlayer>().moveSpeed *= velocityIncrement;
        yield return new WaitForSeconds(lightsTime);
        GetComponent<chasePlayer>().moveSpeed /= velocityIncrement;
        lights.SetActive(true);
    }

    IEnumerator NubeVeneno()
    {

        Instantiate(nubeGas);
        timer += nubeGasTime;
        GetComponent<chasePlayer>().moveSpeed /= velocityDecrement;
        yield return new WaitForSeconds(nubeGasTime);
        GetComponent<chasePlayer>().moveSpeed *= velocityDecrement;
    }
}

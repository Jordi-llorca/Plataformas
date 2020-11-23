using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    
    public int maxVida = 100;
    float actualVida;

    public bool inmortal = false;
    public float tiempoInmortal = 1.0f;
    public float limitecaida = -20.0f;

    public barraJetPack healthBar;
    private void Start()
    {
       
        actualVida = maxVida;
        healthBar.SetMaxFuel(maxVida);
    }

    private void Update()
    {
        if (actualVida > maxVida)
            actualVida = maxVida;

        if (actualVida <= 0)
            Muerte();

        if (transform.position.y <= limitecaida)
            Muerte();

    }

    public void QuitarVida(float daño)
    {
        if (inmortal) return;
        
        actualVida -= daño;
        //animation of getting hurt
        //animator.SetTrigger("Hurt");
        StartCoroutine(TiempoInmortal());

        healthBar.SetFuel(actualVida);
    }

    public void DarVida(float vida)
    {
        actualVida += vida;
        healthBar.SetFuel(actualVida);
    }


   void Muerte()
    {
        //animation of dying
        //animator.SetBool("isDead",true);
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }

   

    IEnumerator TiempoInmortal()
    {
        inmortal = true;
        yield return new WaitForSeconds(tiempoInmortal);
        inmortal = false;
    }

    
}

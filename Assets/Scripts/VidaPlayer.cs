using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public int maxVida = 100;
    int actualVida;

    public bool inmortal = false;
    public float tiempoInmortal = 1.0f;
    public float limitecaida = -20.0f;
  

    private void Start()
    {
       
        actualVida = maxVida;

    }

    private void Update()
    {
        if (actualVida > maxVida)
            actualVida = maxVida;

        if (actualVida <= 0)
            Muerte();

        if (transform.positon.y <= limitecaida)
            Muerte();
    }

    public void QuitarVida(float daño)
    {
        if (inmortal) return;
        
        actualVida -= daño;
        //animation of getting hurt
        //animator.SetTrigger("Hurt");
        StartCoroutine(TiempoInmortal());
    }

    public void DarVida(float vida)
    {
        actualVida += vida;
    }


   void Muerte()
    {
        //animation of dying
        //animator.SetBool("isDead",true);
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver");
      
    }

   

    IEnumerator TiempoInmortal()
    {
        inmortal = true;
        yield return new WaitForSeconds(tiempoInmortal);
        inmortal = false;
    }
}

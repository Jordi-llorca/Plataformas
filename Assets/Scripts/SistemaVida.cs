using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVida : MonoBehaviour
{
    public float maxVida = 100.0f;
    float actualVida;

    public bool inmortal = false;
    public float tiempoInmortal = 1.0f;

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
    }

    public void QuitarVida(float daño)
    {
        if (inmortal) return;
        
        actualVida -= daño;
        StartCoroutine(TiempoInmortal());
    }

    public void DarVida(float vida)
    {
        actualVida += vida;
    }

    public void Muerte()
    {
        Destroy(this.gameObject); 
    }

    IEnumerator TiempoInmortal()
    {
        inmortal = true;
        yield return new WaitForSeconds(tiempoInmortal);
        inmortal = false;
    }

    
}

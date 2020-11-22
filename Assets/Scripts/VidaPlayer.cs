﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaVida : MonoBehaviour
{
    
    public float maxVida = 100.0f;
    float actualVida;

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

        if (transform.position.y <= limitecaida)
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
        SceneManager.LoadScene("GameOver");
      
    }

   

    IEnumerator TiempoInmortal()
    {
        inmortal = true;
        yield return new WaitForSeconds(tiempoInmortal);
        inmortal = false;
    }

    
}

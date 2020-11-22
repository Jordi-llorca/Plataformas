using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraMovement : MonoBehaviour
{
    public GameObject jugador;
    public float limiteInferior;
    public float limiteSuperior;
    private void FixedUpdate()
    {
        
        transform.position = new Vector3(jugador.transform.position.x, 0 , transform.position.z);
        transform.position = new Vector3(0, jugador.transform.position.y, transform.position.z);
        if(transform.position.y<=1.627803)
        {
            transform.position=new Vector3(0, 1.627803f,-10);
        }
        if (jugador.transform.position.y > limiteInferior && jugador.transform.position.y < limiteSuperior)
            transform.position = new Vector3(0, jugador.transform.position.y, transform.position.z);
        else if(jugador.transform.position.y < limiteInferior)
            transform.position = new Vector3(0, limiteInferior, transform.position.z);
        else
            transform.position = new Vector3(0, limiteSuperior, transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraMovement : MonoBehaviour
{
    public GameObject jugador;

    private void FixedUpdate()
    {
        transform.position = new Vector3(jugador.transform.position.x, 0 , transform.position.z);
        transform.position = new Vector3(0, jugador.transform.position.y, transform.position.z);
    }
}

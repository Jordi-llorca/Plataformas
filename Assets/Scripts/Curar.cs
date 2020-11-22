using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curar : MonoBehaviour
{
    public float vida = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SistemaVida>() != null)
        {
            other.gameObject.GetComponent<SistemaVida>().DarVida(vida);
        }

    }
}

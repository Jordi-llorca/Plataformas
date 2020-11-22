using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curar : MonoBehaviour
{
    public float vida = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<VidaPlayer>() != null)
        {
            other.gameObject.GetComponent<VidaPlayer>().DarVida(vida);
        }

    }
}

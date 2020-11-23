using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour
{
    public GameObject pisotonEffect;
    public GameObject player;

    public float damagePisoton;
    void Pisoton()
    {
        Instantiate(pisotonEffect, transform.position, Quaternion.identity);
        if (player.GetComponent<playerMovment>().isGrounded())
        {
            player.GetComponent<VidaPlayer>().QuitarVida(damagePisoton);
        }
    }

    void NubeCegante()
    {

    }

    void NubeVeneno()
    {
        
    }
}

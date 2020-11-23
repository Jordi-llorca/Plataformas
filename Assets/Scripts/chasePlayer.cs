using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour
{
    public Transform player;
    public float Range;
    public float moveSpeed;
    Rigidbody2D rb;
    public Transform LCheck;
    public Transform RCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (GetComponent<EnemyCombat>().alive)
        {
            if(distToPlayer<Range)
            {
                ChasePlayer();
            } else 
            {
                StopChasingPlayer();
            }
        }
    }
        

    private void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0,0);
    }

    public void ChasePlayer()
    {

        if(transform.position.x<player.position.x && RCheck.position.x > transform.position.x)
        {
            //move to right
            rb.velocity = new Vector2(moveSpeed,0);
        }
        else if (transform.position.x >player.position.x && LCheck.position.x < transform.position.x)
        {
            //move to left
            rb.velocity = new Vector2(-moveSpeed,0);
        } 
    }
}

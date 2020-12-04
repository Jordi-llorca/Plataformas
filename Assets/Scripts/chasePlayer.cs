using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour
{
    public Transform player;
    public float Range;
    public float moveSpeed;
    float localSpeed;
    Rigidbody2D rb;
    public Transform LCheck;
    public Transform RCheck;

    public GameObject projectile;
    public float shotTime;
    float timeToShot;

    public Animator animator;

    public bool volador = false;
    public bool boss = false;
    bool right = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localSpeed = moveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (GetComponent<EnemyCombat>().alive)
        {
            if(Mathf.Abs(transform.position.x - player.position.x) < 1) StopChasingPlayer();
            if (transform.position.y - player.position.y > 1 && !volador && !boss) StopChasingPlayer();
            else if (volador && transform.position.y - player.position.y < 1) StopChasingPlayer();
            else if(distToPlayer<Range)
            {
                ChasePlayer();
                if (volador) { shotProjectile();}
            } 
            else 
            {
                StopChasingPlayer();
            }

            
        }
    }

    void shotProjectile()
    {
        if (timeToShot <= 0)
        {
            animator.SetTrigger("Attack");
            Instantiate(projectile, transform.position, transform.rotation);
            timeToShot = shotTime;
        }
        else
            timeToShot -= Time.fixedDeltaTime;
    }
    private void StopChasingPlayer()
    {
        if(!boss) animator.SetBool("chasing", false);
        int mov = right ? 1 : -1;
        transform.Translate(Vector3.right * localSpeed * mov * Time.deltaTime);
        if (RCheck.position.x < transform.position.x && right)
        {
             transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
             right = false;
        }
        else if (LCheck.position.x > transform.position.x && !right)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            right = true;
        }
    }

    public void ChasePlayer()
    {
        if (!boss) animator.SetBool("chasing", true);
        localSpeed = moveSpeed;
        if (transform.position.x < player.position.x && RCheck.position.x > transform.position.x)
        {
            //move to right
            transform.Translate(Vector3.right * localSpeed * Time.deltaTime);
            if (!right)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                right = true;
            }
        }
        else if (transform.position.x > player.position.x && LCheck.position.x < transform.position.x)
        {
            //move to left
            transform.Translate(Vector3.right * -localSpeed * Time.deltaTime);
            if (right)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                right = false;
            }
        } 
    }
}

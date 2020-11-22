﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;
    public Animator animator;
    public bool alive=true;
    void Start()
    {
        currentHealth=maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth-=damage;

        //animation of getting hurt
        //animator.SetTrigger("Hurt");
        if (currentHealth<=0)
        {
            Die();
        }
    }
    void Die()
    {
        //animation of dying
        //animator.SetBool("isDead",true);
        GetComponent<Collider2D>().isTrigger=true;
        GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeAll;
        alive=false;
    }
}

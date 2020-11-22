using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyCombat : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    public static bool alive = true;

    public GameObject projectile;
    public float shotTime;
    float timeToShot;
    void Start()
    {
        currentHealth = maxHealth;
        timeToShot = shotTime;
    }
    void FixedUpdate()
    {

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //animation of getting hurt
        //animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //animation of dying
        //animator.SetBool("isDead",true);
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        alive = false;
    }

    void shotProjectile()
    {
 
     Instantiate(projectile, transform.position, transform.rotation);
    }
}

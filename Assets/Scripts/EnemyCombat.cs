using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;
    public Animator animator;
    public bool alive=true;
    public float damage;
    public LayerMask whatIsSolid;
    void Start()
    {
        currentHealth=maxHealth;
    }

    private void FixedUpdate()
    {
        MakeDamage(damage);
    }
    public void MakeDamage(float damage)
    {
        if (alive)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, Mathf.Infinity, whatIsSolid);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    hitInfo.collider.GetComponent<VidaPlayer>().QuitarVida(damage);
                }
            }
        }
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
        //GetComponent<Collider2D>().isTrigger=true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        alive =false;
        EnemyCounter.decreaseEnemys();
    }
}

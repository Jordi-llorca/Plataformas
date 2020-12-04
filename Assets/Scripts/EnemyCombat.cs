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

    public bool boss = false;
    public barraJetPack bossBar;

    public GameObject loader;
    void Start()
    {
        currentHealth=maxHealth;
        if (boss) bossBar.SetMaxFuel(maxHealth);
    }

    private void FixedUpdate()
    {
        MakeDamage(damage);
    }
    public void MakeDamage(float damage)
    {
        if (alive)
        {
            Vector3 prsjPos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            RaycastHit2D hitInfo = Physics2D.Raycast(prsjPos, transform.forward, Mathf.Infinity, whatIsSolid);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    FindObjectOfType<AudioManager>().Play("Imapct");
                    hitInfo.collider.GetComponent<VidaPlayer>().QuitarVida(damage);
                }
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (alive)
        {
            FindObjectOfType<AudioManager>().Play("ImpactMetal");
            currentHealth -= damage;
            if (boss) bossBar.SetFuel(currentHealth);
            //animation of getting hurt
            //animator.SetTrigger("Hurt");
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        //animation of dying
        
        //GetComponent<Collider2D>().isTrigger=true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        alive =false;
        if (!boss) { EnemyCounter.decreaseEnemys(); animator.SetTrigger("die"); }
        else { loader.GetComponent<levelLoder>().LoadNextLevel(); }
    }
}

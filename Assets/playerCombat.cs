using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    
    //public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage=40;
    public float attackRate=2f;
    float nextAttackTime=0f;
    void Update()
    {
        if(Time.time>=nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
             Attack();
             nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {   
        //attacking animation
        //animator.SetTrigger("Attack");
        //detecting enemies
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //daño
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyCombat>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint==null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform LCheck;
    public Transform RCheck;


    public float velocity;
    int movement = 1;

    public GameObject projectile;
    public float shotTime;
    float timeToShot;
    void FixedUpdate()
    {
        if (GetComponent<EnemyCombat>().alive)
        {

            //transform.Translate(Vector3.right * velocity * movement * Time.deltaTime);
            if (projectile != null) shotProjectile();
            //if (LCheck.position.x >= transform.position.x && movement != 1) movement *= -1;
            //if (RCheck.position.x <= transform.position.x && movement != -1) movement *= -1;

        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    void shotProjectile()
    {
        if (timeToShot <= 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            timeToShot = shotTime;
        }
        else
            timeToShot -= Time.fixedDeltaTime;
    }
}

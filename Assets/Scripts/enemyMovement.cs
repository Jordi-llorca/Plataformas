using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    bool Lgrounded = false;
    bool Rgrounded = false;
    float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform LgroundCheck;
    public Transform RgroundCheck;

    public float velocity;
    int movement = 1;

    void FixedUpdate()
    {
        if(GetComponent<EnemyCombat>().alive==true)
        {
            Lgrounded = Physics2D.OverlapCircle(LgroundCheck.position, groundCheckRadius, groundLayer);
            Rgrounded = Physics2D.OverlapCircle(RgroundCheck.position, groundCheckRadius, groundLayer);
            transform.Translate(Vector3.right * velocity * movement * Time.deltaTime);

            if (!Lgrounded && movement != 1) movement *= -1;
            if (!Rgrounded && movement != -1) movement *= -1;
        }
    }
}

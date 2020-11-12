using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    //Movimiento Horizontal
    public float movVel = 5f;
    float movement;

    //Movimiento Vertical
    public float velVert = 5f;
    public float maximoJetpack = 10f;
    float tiempoJetpack;
    public float fuerzaJetpack = 3f;

    //Ground Checker
    bool grounded = false;
    float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    void Start()
    {
        tiempoJetpack = maximoJetpack;
    }

    
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * movement * movVel * Time.deltaTime);
        movimientoVertical();
    }

    void movimientoVertical()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, velVert), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.Space) && tiempoJetpack > 0)
        {
            //transform.Translate(Vector3.up * 10 * Time.deltaTime);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaJetpack), ForceMode2D.Impulse);
            tiempoJetpack -= Time.deltaTime;
        }
        else if(grounded && tiempoJetpack < maximoJetpack) tiempoJetpack += Time.deltaTime;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}

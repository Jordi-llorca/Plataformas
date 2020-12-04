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
    public float maxFuel = 10f;
    public float jetForce = 10f;
    public float jetWait;
    public float jetRecovery;
    float currentRecovery;
    float currentFuel;
    bool canJet;
    public barraJetPack fuelBar;
    Rigidbody2D rig;

    //Ground Checker
    bool grounded = true;
    float groundCheckRadius = 0.01f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    //Animator
    public Animator animator;
    float scalex;
   
    void Start()
    {
        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);

        rig = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        scalex = transform.localScale.x;
    }

    
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("a") )
        {
            animator.SetTrigger("correr");
            transform.localScale = new Vector2(-scalex,transform.localScale.y);
        }
        if (Input.GetKeyDown("d") )
        {
            animator.SetTrigger("correr");
            transform.localScale = new Vector2(scalex,transform.localScale.y);
            
        }
        if (Input.GetKeyUp("a")){animator.SetTrigger("idle");}
        if (Input.GetKeyUp("d")){animator.SetTrigger("idle");}
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * movement * movVel * Time.deltaTime);
        movimientoVertical();
    }

    void movimientoVertical()
    {
        bool jet = Input.GetKey(KeyCode.Space);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (jump && grounded)
        {
            animator.SetBool("volando", true);
            grounded = false;
            rig.AddForce(new Vector2(0, velVert), ForceMode2D.Impulse);
            
        }
        if (!grounded) canJet = true;
        if (grounded) canJet = false;

        if(canJet && jet && currentFuel > 0)
        {
            rig.velocity = Vector2.up * jetForce;
            //rig.AddForce(Vector2.up * jetForce);
            currentFuel = Mathf.Max(0, currentFuel - Time.fixedDeltaTime);
        }

        if (grounded)
        {
            animator.SetBool("volando", false);
            if (currentRecovery < jetWait)
                currentRecovery = Mathf.Min(maxFuel, currentFuel + Time.fixedDeltaTime);
            else
                currentFuel = Mathf.Min(maxFuel, currentFuel + Time.fixedDeltaTime * jetRecovery);
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        fuelBar.SetFuel(currentFuel);
    }

    public bool isGrounded() { return grounded; }
}

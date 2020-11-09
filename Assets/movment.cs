using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public float movSpeed = 600f;
    float movement = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, movement * Time.deltaTime * movSpeed);
    }
}

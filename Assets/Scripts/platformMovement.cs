using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
    public Transform LCheck;
    public Transform RCheck;

    public float velocity;
    int movement = 1;

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * velocity * movement * Time.deltaTime);

        if (LCheck.position.x >= transform.position.x && movement != 1) movement *= -1;
        if (RCheck.position.x <= transform.position.x && movement != -1) movement *= -1;
    }
}

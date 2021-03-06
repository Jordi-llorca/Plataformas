﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public float damage;
    public float lifeTime = 5f;
    public float lenght = 20;
    float timer;
    private void Start()
    {
        timer = lifeTime;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        Vector3 prsjPos = new Vector3(transform.position.x - lenght/2, transform.position.y + 0.5f, transform.position.z);
        RaycastHit2D hitInfo = Physics2D.Raycast(prsjPos, transform.right, lenght);
        Debug.DrawRay(prsjPos, transform.right * lenght, Color.green);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<VidaPlayer>().QuitarVida(damage);
            }
        }
        if (timer <= 0) Destroy(this.gameObject);
    }
    
}

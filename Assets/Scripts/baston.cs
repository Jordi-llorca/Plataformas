﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baston : MonoBehaviour
{
    public float offset=-90f;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots=0.25f;
    public barraJetPack staminaBar;
    float stamina;
    void Start()
    {
        staminaBar.SetMaxFuel(startTimeBtwShots);
        staminaBar.SetFuel(startTimeBtwShots);
        stamina = startTimeBtwShots;
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotZ + offset);

        staminaBar.SetFuel(stamina);
        if(timeBtwShots<=0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                staminaBar.SetFuel(0);
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                stamina=0;
            }
        }else{
        
            timeBtwShots -=Time.deltaTime;
            stamina+=Time.deltaTime;
        } 
    }
}

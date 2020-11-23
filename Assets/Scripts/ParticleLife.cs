using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLife : MonoBehaviour
{

    public float lifeTime;
    float currentLife;
    private void Start()
    {
        currentLife = lifeTime;
    }
    void Update()
    {
        currentLife -= Time.deltaTime;
        if (currentLife <= 0) Destroy(gameObject);
    }
}

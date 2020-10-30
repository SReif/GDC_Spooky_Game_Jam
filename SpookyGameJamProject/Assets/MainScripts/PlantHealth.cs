using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHealth : MonoBehaviour
{

    public float health; //health
    public float maxHealth;

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0) { Destroy(gameObject); } //if health hits zero, destroys the unit
    }

}

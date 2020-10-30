using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHealth : MonoBehaviour
{

    public float health; //health
    public float maxHealth;

    public HealthBar healthBar;

    void Start()
    {
        maxHealth = health;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0) { Destroy(gameObject); } //if health hits zero, destroys the unit
        healthBar.SetHealth(health);
    }

}

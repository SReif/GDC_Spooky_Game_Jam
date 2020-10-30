﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHealth : MonoBehaviour
{

    public int health; //health
    public HealthBar healthBar;

    void Update()
    {

        if (health <= 0) { Destroy(gameObject); } //if health hits zero, destroys the unit
        healthBar.SetHealth(health);
    }

}

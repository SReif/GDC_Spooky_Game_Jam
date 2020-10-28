using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;
    public GameObject waterCan;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        WaterCan(false);
    }

    void Update()
    {
        waterCan.transform.position = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition, 0); 

        if (Input.GetKeyUp(KeyCode.Space))
        {
            TakeDamage(10.0f);
        }

        if(Input.GetMouseButton(1))
        {
            RestoreHealth(0.1f);
            WaterCan(true);
        }

        else
        {
            WaterCan(false);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void RestoreHealth(float healing)
    {
        currentHealth += healing;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    void WaterCan(bool visible)
    {
        waterCan.SetActive(visible);
    }
}

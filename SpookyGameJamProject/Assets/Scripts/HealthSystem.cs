using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    //public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            TakeDamage(10);
        }

        else if(other.gameObject.tag == "player")
        {
            RestoreHealth(0.1f);
        }
    }

    public void TakeDamage(float damage)
    {
        //decrease health based on damage
        currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
    }

    public void RestoreHealth(float healing)
    {
        //increase health based on healing
        currentHealth += healing;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //healthBar.SetHealth(currentHealth);
    }
}

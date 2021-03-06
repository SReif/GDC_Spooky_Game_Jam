﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireScript : MonoBehaviour
{

    private GameObject spawnerReference;
    private EnemySpawnerScript enemySpawnerScript;

    public int health;

    public float movementSpeed;
    private Vector3 transformMovement;
    private Vector3 velocity;
    private bool canAttack;
    private GameObject currentTarget;

    public float attackRate;
    private float attackTimer;
    public int attackDamage;

    private int row;

    void Start()
    {

        attackTimer = 0f;

        if (transform.position.y == 2) { row = 1; }
        else if (transform.position.y == 0) { row = 2; }
        else if (transform.position.y == -2) { row = 3; }

        spawnerReference = GameObject.FindGameObjectWithTag("Spawner");
        enemySpawnerScript = spawnerReference.GetComponent<EnemySpawnerScript>();

        canAttack = false;

        velocity = new Vector3(movementSpeed, 0f, 0f);

    }


    void Update()
    {

        if (health <= 0)
        {
            enemySpawnerScript.enemyCount[0]--;
            enemySpawnerScript.enemyCount[row]--;
            Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {

        attackTimer = attackTimer + Time.deltaTime;

        if (!canAttack) { Movement(); }
        else if (canAttack) { Attack(); }

    }

    void Movement()
    {

        transformMovement = transform.position;

        transformMovement = transformMovement - velocity;

        transform.position = transformMovement;

    }

    void Attack()
    {

        if (attackTimer >= attackRate)
        {

            
             PlantHealth plantHealth = currentTarget.GetComponent<PlantHealth>();
             plantHealth.health = plantHealth.health - attackDamage;
             health = health + (attackDamage/2);
             
            attackTimer = 0;
            if (currentTarget.tag == "Base")
            {
                this.health = 0;
            }
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Base")
        {

            canAttack = true;

            currentTarget = collision.gameObject;
            

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            canAttack = false;
            //currentTarget = null;
        }
    }
}

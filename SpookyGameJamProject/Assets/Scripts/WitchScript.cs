﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchScript : MonoBehaviour
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

        if (transform.position.y == 0) { row = 1; }
        else if (transform.position.y == 64) { row = 2; }
        else if (transform.position.y == 128) { row = 3; }

        spawnerReference = GameObject.FindGameObjectWithTag("Spawner");
        enemySpawnerScript = spawnerReference.GetComponent<EnemySpawnerScript>();

        canAttack = false;

        velocity = new Vector3(movementSpeed, 0f, 0f);

    }


    void Update()
    {

        if (health <= 0)
        {

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

            /*
             PlantHealth plantHealth = currentTarget.GetComponent<PlantHealth>();
             plantHealth.health = plantHealth.health - damage;
            --or--
            create another bullet script, make the velocity negative, and instantiate it here
             */
            attackTimer = 0;

        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            canAttack = true;

            currentTarget = collision.gameObject;

        }

    }
}
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{

    private GameObject spawnerReference;
    private EnemySpawnerScript enemySpawnerScript;

    public int healthBarOne;
    public int healthBarTwo;
    public int health;
    private bool hasDied;

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

        hasDied = false;
        attackTimer = 0f;
        health = healthBarOne;
        
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

        if ((health <= 0) && (!hasDied)) 
        {

            health = healthBarTwo;
            hasDied = true;

        } else if ((health <= 0) && (hasDied))
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

            
             PlantHealth plantHealth = currentTarget.GetComponent<PlantHealth>();
             plantHealth.health = plantHealth.health - attackDamage;
             
            attackTimer = 0;
            if(currentTarget.tag == "Base")
            {
                Destroy(this.gameObject);
            }
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Base")
        {

            UnityEngine.Debug.Log("Collision!");

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

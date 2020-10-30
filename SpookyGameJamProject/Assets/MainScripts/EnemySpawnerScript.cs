using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public GameObject[] enemiesArray; //this array holds our prefabs of our enemies for the script to pull from
    public int[] enemyCount; //this array will keep track of how many enemies total are on the screen, and then how many enemies are in row 1, row 2, and row 3 !!DO NOT EDIT!!
    private int enemySelection; //this value will be used to randomize which enemy is spawned
    private int rowSelection; //this value will be used to randomize which row an enemy spawns on
    public int screenEnemyCap; //this value will be used to cap how many enemies we have on screen
    public int rowEnemyCap; //this value will be used to cap how many enemies we can have in each row

    private float firstY; //this value holds the intial Y value of the top of the first row
    private Vector3 enemyPlacement; //we will use this to determine where the enemies are spawned

    public float spawnRate; //this value changes the delay between enemy spawns
    private float spawnTimer; //this value keeps track of how long it has been since the last enemy has spawned

    void Start()
    {
        spawnTimer = 0; //formality setting of a value
        firstY = 2.0f; //formality setting of a value
        enemyCount[0] = 0; //formality setting of a value, [0] will be total enemies on screen
        enemyCount[1] = 0; //formality setting of a value, [1] will be total enemies on row 1
        enemyCount[2] = 0; //formality setting of a value, [2] will be total enemies on row 2
        enemyCount[3] = 0; //formality setting of a value, [3] will be total enemies on row 3
    }

    
    void Update()
    {

        spawnTimer = spawnTimer + Time.deltaTime; //the timer in action

        //first, it checks to see if we have hit the spawn timer, then if there are too many enemies on screen already, then if there is room in any of the rows
        if ((spawnTimer >= spawnRate) && (enemyCount[0] < screenEnemyCap) && (enemyCount[1] < rowEnemyCap) && (enemyCount[2] < rowEnemyCap) && (enemyCount[3] < rowEnemyCap))
        {
            EnemySpawn(); //when the timer hits the spawnRate value, executes enemy spawn
            spawnTimer = 0; //resets the timer to 0
        }  
    }

    void EnemySpawn()
    {

        enemySelection = UnityEngine.Random.Range(0, 3); //randomly pulls an int between 0 and 2 to correspond with the 3 spots in the enemiesArray
        Debug.Log(enemySelection);

        bool enemyDidNotSpawn = true; //initially sets this bool to true to open the following while loop

        while(enemyDidNotSpawn) //this while loop ensures that if the system tries to place an enemy on a row where there are too many enemies, the system tries again
        {

            rowSelection = UnityEngine.Random.Range(1, 4); //randomly pulls an int between 1 and 3 to correspond with the 3 rows in enemyCount

            if (enemyCount[rowSelection] < rowEnemyCap) //if the amount of enemies in the row hasn't hit the cap
            {

                float rowY = 0f; //formality setting a value
                if (rowSelection == 1) { rowY = firstY; } //will place the enemy in the first row
                else if (rowSelection == 2) { rowY = firstY - 2.0f; } //will place the enemy in the second row
                else if (rowSelection == 3) { rowY = firstY - 4.0f; } //will place the enemy in the third row

                enemyPlacement = new Vector3(transform.position.x, rowY, 0f); //creates the placement of the enemy

                Instantiate((enemiesArray[enemySelection]), enemyPlacement, transform.rotation); //creates the enemy

                enemyCount[rowSelection]++; //adds an enemy count to that row
                enemyCount[0]++; //adds an enemy count to the total enemies
                enemyDidNotSpawn = false; //leaves the while loop
            }  
        }

    }

}

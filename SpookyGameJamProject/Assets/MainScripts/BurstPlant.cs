using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstPlant : MonoBehaviour
{

    public GameObject bullet; //place the burst plant's bullet in the unity editor here
    public float fireRate; //how fast the plant shoots
    public float burstRate; //time between each round in the burst shot
    private float fireTimer; //used to keep track of time between fires
    private float burstTimer; //used to keep track of time between burst shots
    private bool firing; //keeps track of whether or not the plant should be firing or not
    private int timesFired; //keeps track of how many times the plant has shot in its current burst round

    void Start()
    {

        fireTimer = 0f; //formality value setting
        burstTimer = 0f; //formality value setting
        firing = false; //formality value setting
        timesFired = 0; //formality value setting
        
    }


    void Update()
    {

        fireTimer = fireTimer + Time.deltaTime; //the actual timer in use

        if (fireTimer >= fireRate) //if enough time has passed since the last time the plant has shot
        {

            firing = true; //it can now shoot

        }

        if ((firing) && (timesFired <= 2)) //if the plant is able to shoot and hasn't shot all of its burst rounds yet
        {

            burstTimer = burstTimer + Time.deltaTime; //the burst timer in use

            if (burstTimer >= burstRate) //if enough time has passed since the last round in the burst shot
            {

                Instantiate(bullet, transform.position, transform.rotation); //make a bullet

                timesFired++; //add another counter to the times shot this burst

                burstTimer = 0f; //reset burst counter

            }

        }

        if ((firing) && (timesFired == 3)) //if the plant is able to shoot but it has shot all of its burst rounds
        {

            firing = false; //turn off plants ability to shoot
            fireTimer = 0f; //reset fire timer
            timesFired = 0;

        }
        
    }
}

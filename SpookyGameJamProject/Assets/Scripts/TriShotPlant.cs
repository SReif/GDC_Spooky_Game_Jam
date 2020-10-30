using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriShotPlant : MonoBehaviour
{
    public GameObject bullet; //bullet goes here
    public float fireRate; //how fast the plant shoots
    private float fireTimer; //used to keep track of how long it has been
    public float spread; //the angle in degrees of the spread of the trishot

    void Start()
    {

        fireTimer = 0f; //formality value setting

    }


    void Update()
    {

        fireTimer = fireTimer + Time.deltaTime; //timer in acction

        if (fireTimer >= fireRate) //if enough time has passed since the last shot
        {

            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, spread)); //create bullet upward
            Instantiate(bullet, transform.position, transform.rotation); //create bullet foward
            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -spread)); //create bullet downward

            fireTimer = 0; //reset timer

        }

    }
}

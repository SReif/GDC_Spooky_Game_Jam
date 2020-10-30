using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotarPlant : MonoBehaviour
{
    public GameObject bullet; //put bullet here
    public float fireRate; //how fast the plant shoots
    private float fireTimer; //the actual timer
    private Vector3 explosionPosition; //where the explosion should go
    public float distance; //how far away from the mortar the explosion should be

    void Start()
    {

        fireTimer = 0f; //formality value setting

        explosionPosition = transform.position; //take the mortar's position
        explosionPosition.x = explosionPosition.x + distance; //add your distance to it

    }


    void Update()
    {

        fireTimer = fireTimer + Time.deltaTime; //timer in action

        if (fireTimer >= fireRate) //if our fire rate time has passed
        {

            Instantiate(bullet, explosionPosition, transform.rotation); //create explosion

            fireTimer = 0; //reset timer

        }

    }
}

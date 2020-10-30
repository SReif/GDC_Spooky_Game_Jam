using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float bulletSpeed; //how fast does bullet go
    public int bulletDamage; //how much damage does each bullet does

    private Vector3 velocity; //used to actually apply the speed to the bullet
    private Vector3 movement; //again, used to actually apply the speed to the bullet

    void Start()
    {

        velocity = new Vector3(bulletSpeed, 0f, 0f); //take the speed and put it in the Vector3 for application
        velocity = transform.rotation * velocity; //rotate the vector so that it will travel in the direction we want - more for use for the trishot plant's spreadshot
        
    }

    void Update()
    {

        movement = transform.position; //put the current position in movement
        movement = movement + velocity; //add our velocity
        transform.position = movement; //put that back in our position

        if (transform.position.x >= 9) { Destroy(gameObject); } //if the bullet goes past camera view, destroy it
        
    }

    void OnCollisionEnter2D(Collision2D collision) //detect collision
    {

        if (collision.gameObject.tag == "Enemy") //check to see if what we are colliding with is an enemy
        {

            if (collision.gameObject.name == "SkeletonPrefab") //if it's a Skeleton
            {

                SkeletonScript skeletonScript = collision.gameObject.GetComponent<SkeletonScript>(); //get the Skeleton's script
                skeletonScript.health = skeletonScript.health - bulletDamage; //subtract the bullet's damage from the Skeleton's health
                Destroy(gameObject); //destroy the bullet

            }
            else if (collision.gameObject.name == "VampirePrefab") //if it's a Vampire
            {

                VampireScript vampireScript = collision.gameObject.GetComponent<VampireScript>(); //get the Vampire's script
                vampireScript.health = vampireScript.health - bulletDamage; //subtract the bullet's damage from the Vampire's health
                Destroy(gameObject); //destroy the bullet

            }
            else if (collision.gameObject.name == "WitchPrefab") //if it's a Witch
            {

                WitchScript witchScript = collision.gameObject.GetComponent<WitchScript>(); //get the Witch's script
                witchScript.health = witchScript.health - bulletDamage; //subtract the bullet's damage from the Witch's health
                Destroy(gameObject); //destroy the bullet

            }

        }

    }

}

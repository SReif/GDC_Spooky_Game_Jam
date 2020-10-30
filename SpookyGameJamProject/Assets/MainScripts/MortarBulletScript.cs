using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBulletScript : MonoBehaviour
{
    
    public int bulletDamage; //how much damage does each bullet does
    public float duration; //tweak to get how long the explosion lasts on the ground
    private float timer; //timer to help keep track of how long the explosion has lasted
   

    void Start()
    {

        timer = 0; //formality value setting

    }

    void Update()
    {

        timer = timer + Time.deltaTime; //timer is action

      if (timer >= duration) //if the explosion has lasted as long as the duration says it should
        {

            Destroy(gameObject); //get rid of the explosion

        }

    }

    void OnTriggerEnter2D(Collider2D collision) //checks for collision, this section works EXACTLY the same as a regular bullet
    {

        if (collision.gameObject.tag == "Enemy")
        {

            if (collision.gameObject.name == "SkeletonPrefab(Clone)")
            {

                SkeletonScript skeletonScript = collision.gameObject.GetComponent<SkeletonScript>();
                skeletonScript.health = skeletonScript.health - bulletDamage;

            }
            
            if (collision.gameObject.name == "VampirePrefab(Clone)")
            {

                VampireScript vampireScript = collision.gameObject.GetComponent<VampireScript>();
                vampireScript.health = vampireScript.health - bulletDamage;

            }
            
            if (collision.gameObject.name == "WitchPrefab(Clone)")
            {

                WitchScript witchScript = collision.gameObject.GetComponent<WitchScript>();
                witchScript.health = witchScript.health - bulletDamage;

            }

        }

    }
}

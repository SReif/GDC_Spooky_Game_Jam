using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    //public HealthSystem healthSystem;
    public PlantHealth plantHealth;
    private Vector3 objPosition;
    private bool rotated;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        //Update watering can position
        this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(
            (Vector2)Input.mousePosition, 0);

        FeedWater();
    }

    void FeedWater()
    {
        do
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
            rotated = true;
        } while (plantHealth.health < plantHealth.maxHealth && rotated == false);

        //Restores health if sprite is active and player is holding mouse click
        if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true && Input.GetMouseButton(0) && plantHealth.health < plantHealth.maxHealth)
        {
            plantHealth.health += 0.1f;
        }

        if(plantHealth.health == plantHealth.maxHealth)
        {
            rotated = false;
            this.gameObject.transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //disables watering can and de-links health system of collided object
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            plantHealth = collision.gameObject.GetComponent<PlantHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //disables watering can and de-links health system of collided object
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            plantHealth = null;
        }
    }
}

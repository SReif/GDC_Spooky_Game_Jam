using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    public HealthSystem healthSystem;

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
        //Restores health if sprite is active and player is holding mouse click
        if(this.gameObject.GetComponent<SpriteRenderer>().enabled == true && Input.GetMouseButton(0))
        {
            healthSystem.RestoreHealth(0.1f);
        }

        //*********REMOVE BELOW CODE****************
        if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true && Input.GetMouseButtonDown(1))
        {
            healthSystem.TakeDamage(10f);
        }
        //*****************************************
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //enables watering can and links health system of collided object
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            healthSystem = collision.gameObject.GetComponent<HealthSystem>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //disables watering can and de-links health system of collided object
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            healthSystem = null;
        }
    }
}

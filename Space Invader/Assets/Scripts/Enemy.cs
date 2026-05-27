using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 100;
    
    [SerializeField] GameObject explosionVFX;

    // [SF] variable for enemy laser object
    [SerializeField] GameObject enemyLaser;
    // [SF] variable for enemy laser shot interval
    [SerializeField] float shotInterval = 0.5f;
    // Variable for the shot count down value
    float shotCoolDown = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player Laser")
        {
            Destroy(collision.gameObject);
            health -= 25;
            if(health <= 0)
            {
                Destroy(gameObject);
                FindObjectOfType<ScoreManager>().AddToScore();
                Instantiate(explosionVFX, transform.position, transform.rotation);
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shotCoolDown = shotInterval;
        // Make the cool down variable have the
        //Value of the
    }

    // Update is called once per frame
    void Update()
    {
        // Count down the count down variable
        shotCoolDown -= Time.deltaTime;
        // Check if the count down has reached zero
        if (shotCoolDown <= 0)
        {
            // Instantiate the enemy laser at the 
                // enemy location and rotation
            Instantiate(enemyLaser, transform.position, transform.rotation);
            // Reset the cool down back to the interval
            shotCoolDown = shotInterval;
        }
    }
    void shotCoolDownCountDown()
    {
        shotCoolDown -= Time.deltaTime;
    }
}

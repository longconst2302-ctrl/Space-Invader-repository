using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject playerLaser;
    [SerializeField] float fireRate = 1.0f;
    [SerializeField] AudioClip shootSFX;
    float laserCoolDown = 0;

    [SerializeField] int health = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy Laser")
        {
            Destroy(collision.gameObject);
            health -= 5;
            if (health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Game Over");
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        laserCoolDown = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
        laserCoolDownCountDown();

    }
    void Movement()
    {
        // If we are pressing down the D key
        if (Input.GetKey(KeyCode.D))
        {
            // Then add to the x position 
            transform.position += new Vector3(0.06f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.06f, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0.06f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -0.06f, 0);
        }
    }

    void Shoot()
    {
        if(Input.GetKey(KeyCode.Space) && laserCoolDown <=  0)
        {
            //Spawn a playerlaser of the player with players's rotation
            Instantiate(playerLaser, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position);
            laserCoolDown = fireRate;
        }
    }
    
    void laserCoolDownCountDown()
    {
        laserCoolDown -= Time.deltaTime;
    }

    public int GetHealth()
    {
        return health;
    }
}

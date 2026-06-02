using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] int health = 500;

    [SerializeField] GameObject enemyLaser;
    [SerializeField] float shotInterval = 0.5f;

    float shotCoolDown;

    float moveSpeed = 2f;
    int direction = 1;

    void Start()
    {
        shotCoolDown = shotInterval;
    }

    void Update()
    {
        // =========================
        // BOSS MOVEMENT (LEFT - RIGHT)
        // =========================
        transform.position += new Vector3(moveSpeed * direction * Time.deltaTime, 0, 0);

        if (transform.position.x > 7)
        {
            direction = -1;
        }
        else if (transform.position.x < -7)
        {
            direction = 1;
        }

        // =========================
        // BOSS SHOOTING
        // =========================
        shotCoolDown -= Time.deltaTime;

        if (shotCoolDown <= 0)
        {
            Instantiate(enemyLaser, transform.position, transform.rotation);
            shotCoolDown = shotInterval;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // =========================
        // TAKE DAMAGE FROM PLAYER
        // =========================
        if (collision.tag == "Player Laser")
        {
            Destroy(collision.gameObject);

            health -= 25;

            if (health <= 0)
            {
                Destroy(gameObject);

                SceneManager.LoadScene("Victory");
            }
        }
    }
}
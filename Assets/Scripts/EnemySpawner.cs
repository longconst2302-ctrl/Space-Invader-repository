using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnOrder;
    [SerializeField] float spawnInterval = 1f;

    // Boss prefab reference
    [SerializeField] GameObject boss;

    float spawnCountDown = 0;
    int spawnIndex = 0;

    bool bossSpawned = false;

    void Start()
    {
        spawnCountDown = spawnInterval;
    }

    void Update()
    {
        // =========================
        // BOSS CHECK (IMPORTANT)
        // =========================
        if (FindObjectOfType<ScoreManager>().GetCurrentScore() >= 200
            && bossSpawned == false)
        {
            Instantiate(boss); // spawn boss

            bossSpawned = true;

            // stop enemy spawning
            gameObject.SetActive(false);

            return;
        }

        // =========================
        // ENEMY SPAWNING SYSTEM
        // =========================
        spawnCountDown -= Time.deltaTime;

        if (spawnIndex >= spawnOrder.Length)
        {
            spawnIndex = 0;
        }

        if (spawnCountDown <= 0)
        {
            Instantiate(spawnOrder[spawnIndex]);
            spawnIndex++;
            spawnCountDown = spawnInterval;
        }
    }
}
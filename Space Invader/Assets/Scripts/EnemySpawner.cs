using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnOrder;
    [SerializeField] float spawnInterval = 1f;
    float spawnCountDown = 0;
    int spawnIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnCountDown = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountDown -= Time.deltaTime;
        
        if(spawnIndex >= spawnOrder.Length)
        {
            spawnIndex = 0;
            // Game Over
        }
        
        if(spawnCountDown <= 0)
        {
            Instantiate(spawnOrder[spawnIndex]);
            spawnIndex++;
            spawnCountDown = spawnInterval;
        }
    }
}

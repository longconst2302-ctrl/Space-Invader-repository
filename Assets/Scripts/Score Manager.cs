using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentScore = 0;

    public void AddToScore()
    {
        currentScore += 10;
        print(currentScore);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
    // Start is called before the first frame update
    void Start()
    {
          currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

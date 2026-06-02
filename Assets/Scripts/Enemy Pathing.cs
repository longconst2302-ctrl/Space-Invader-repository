using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] float moveSpeed = 0.03f;
    int waypointIndex = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        // Container of new position = Getting the position
        transform.position = waypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If we are not at the last waypoint 
        if (waypointIndex <= waypoints.Length - 1)
        {
            // Find the next waypoint postion is
            var targetPosition = waypoints[waypointIndex].transform.position;
            // Move toward that waypoint position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            // If we are at that waypoint position
            if (transform.position == targetPosition)
            {
                // Increment the waypoint index so we can move to the next waypoint
                waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}

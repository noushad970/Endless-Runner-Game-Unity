using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMove : MonoBehaviour
{


    public float startZ = 1.5f; // Starting z position
    public float endZ = -1.5f;   // Ending z position
    public float speed = 2f;     // Movement speed

    private bool movingForward = true; // Flag to determine direction of movement

    void Update()
    {
        if(RatObstacleCollider.ratDied)
        {
            speed = 0f;
        }
        // Check if the object is moving forward
        if (movingForward)
        {
            // Move towards the end position
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // If reached the end position, change direction
            if (transform.position.x >= endZ)
            {
                movingForward = false;
            }
        }
        else
        {
            // Move towards the start position
            transform.Translate(Vector3.back * speed * Time.deltaTime);

            // If reached the start position, change direction
            if (transform.position.x <= startZ)
            {
                movingForward = true;
            }
        }
    }
}

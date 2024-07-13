using UnityEngine;
//attach with player
public class CoinMagnetSystem : MonoBehaviour
{
    public float attractionRadius = 5.0f; // Radius within which coins will be attracted
    public float attractionSpeed = 5.0f; // Speed at which coins will move towards the player

    void Update()
    {
        // Find all objects with the tag "Coin"
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coins)
        {
            // Calculate the distance between the player and the coin
            float distanceToPlayer = Vector3.Distance(transform.position, coin.transform.position);

            // Check if the coin is within the attraction radius
            if (distanceToPlayer <= attractionRadius)
            {
                // Move the coin towards the player
                coin.transform.position = Vector3.MoveTowards(coin.transform.position, transform.position, attractionSpeed * Time.deltaTime);
            }
        }
    }

    // Method called when the player collides with a coin
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a coin
        if (other.gameObject.CompareTag("Coin"))
        {
           
        }
    }

    // Visualize the attraction radius in the editor
   
}

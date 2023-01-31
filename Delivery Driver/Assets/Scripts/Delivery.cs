    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class Delivery : MonoBehaviour
{
    public GameObject[] deliverySpots; // Array to store delivery spot objects
    public TMP_Text scoreText; // Text component to display the score
    public Driver speed; // Reference to the Driver script

    private int currentIndex = 0; // Index of the current delivery spot
    public int points; // Stores the current number of points

    // Start is called before the first frame update
    private void Start()
    {
        // Choose a random delivery spot to start with
        int newIndex = Random.Range(0, deliverySpots.Length);
        currentIndex = newIndex;
        deliverySpots[currentIndex].SetActive(true);
    }

    // Called when the object collides with another object with a 2D collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object collided with a "Drop Off" object
        if (collision.CompareTag("Drop Off"))
        {
            points += 1; // Increase the number of points
            scoreText.SetText(points.ToString()); // Update the score text
            GameObject.FindWithTag("Drop Off").gameObject.SetActive(false); // Deactivate the current delivery spot

            // Choose a new delivery spot
            int newIndex = Random.Range(0, deliverySpots.Length);
            currentIndex = newIndex;
            deliverySpots[currentIndex].SetActive(true);
        }
        // If the object collided with a "Speed Up" object
        else if (collision.CompareTag("Speed Up"))
        {
            speed.moveSpeed += 1.7f; // Increase the movement speed of the player
            Destroy(collision.gameObject); // Destroy the "Speed Up" object
        }
    }
}


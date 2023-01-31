using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Driver : MonoBehaviour
{
    // Declare a reference to the game over screen
    public GameObject gameOverScreen;
    // Declare the time remaining for the game
    public float timeRemaining = 180;
    // Declare a flag to indicate if the timer is running
    public bool timerIsRunning = false;
    // Declare a reference to the time text UI element
    public TMP_Text time;
    // Declare a reference to the points UI element
    public GameObject points;

    // Serialize the steer speed
    [SerializeField] public float steerSpeed = 200f;
    // Serialize the move speed
    [SerializeField] public float moveSpeed = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        // Set the timerIsRunning flag to true
        timerIsRunning = true;
    }

    // Function to display the time
    void DisplayTime(float timeToDisplay)
    {
        // Calculate the minutes
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        // Calculate the seconds
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        // Set the text for the time UI element
        time.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the steer amount
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        // Calculate the move amount
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // Rotate the game object
        transform.Rotate(0, 0, -steerAmount);
        // Translate the game object
        transform.Translate(0, moveAmount, 0);

        if (timerIsRunning)
        {
            // Display the time
            DisplayTime(timeRemaining);
            if (timeRemaining > 1)
            {
                // Decrement the timeRemaining value
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                // If the timeRemaining value is less than or equal to 1, set it to 0
                timeRemaining = 0;
                // Set the timerIsRunning flag to false
                timerIsRunning = false;
                // Set the position of the points UI element
                points.transform.position = new Vector3(405, 200, 0);
                // Set the game over screen to active
                gameOverScreen.SetActive(true);
                // Destroy the Driver script component
                Destroy(this);
            }
        }
    }
}


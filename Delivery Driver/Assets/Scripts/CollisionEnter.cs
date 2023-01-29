using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class Delivery : MonoBehaviour
{
    public GameObject[] deliverySpots;
    private int currentIndex = 0;
    public int points;
    public TMP_Text scoreText;

    private void Start()
    {
        int newIndex = Random.Range(0, deliverySpots.Length);
        currentIndex = newIndex;
        deliverySpots[currentIndex].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Drop Off"))
        {
            points += 1;
            scoreText.SetText(points.ToString());
            Debug.Log("Dropped off Pizza");
            GameObject.FindWithTag("Drop Off").gameObject.SetActive(false);
            int newIndex = Random.Range(0, deliverySpots.Length);
            // Activate new gameobject
            currentIndex = newIndex;
            deliverySpots[currentIndex].SetActive(true);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch");
    }
}

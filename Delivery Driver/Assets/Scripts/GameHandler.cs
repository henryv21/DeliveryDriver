using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    // Declare a reference to the Window_QuestPointer script
    [SerializeField] private Window_QuestPointer window_QuestPointer;

    private void Start()
    {
        // Show the quest pointer window with the position of the GameObject tagged "Drop Off"
        window_QuestPointer.Show(GameObject.FindWithTag("Drop Off").transform.position);
    }

}

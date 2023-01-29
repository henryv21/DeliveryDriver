using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Window_QuestPointer window_QuestPointer;
    private void Start()
    {
        window_QuestPointer.Show(GameObject.FindWithTag("Drop Off").transform.position);
        
    }
}

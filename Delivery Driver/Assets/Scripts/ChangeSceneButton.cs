using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ChangeSceneButton.cs
public class ChangeSceneButton : MonoBehaviour
{
    // UI elements to show while loading the scene
    public GameObject loadingScreen;
    public Slider slider;

    // Loads the scene with the specified index
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    // Loads the scene asynchronously and updates the loading UI
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        // Start the asynchronous scene loading
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        // Wait until the loading is finished
        while (!operation.isDone)
        {
            // Update the loading slider to show the progress
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            // Wait until the next frame
            yield return null;
        }
    }
}

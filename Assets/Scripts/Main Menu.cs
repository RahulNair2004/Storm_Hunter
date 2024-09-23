using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method is called when the Play button is pressed
    public void PlayGame()
    {
        StartCoroutine(LoadSceneAfterDelay(0.5f)); // Adjust the delay time (2 seconds in this case)
    }

    // Coroutine to handle the delayed scene transition
    IEnumerator LoadSceneAfterDelay(float delay)
    {
        // Optionally, you can add some visual or audio effects here (e.g., fading out)
        
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
    }

    // This method is called when the Quit button is pressed
    public void QuitGame()
    {
        Application.Quit();
    }
}

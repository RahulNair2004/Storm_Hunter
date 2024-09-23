using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManager namespace
using System.Collections; // Import for Coroutine

public class TransitionManager1 : MonoBehaviour
{
    public string targetSceneName = "Game"; // Name of the target scene to load
    public float transitionDelay = 3f; // Delay before transitioning to the target scene

    // Call this method to start the transition
    public void StartTransition()
    {
        StartCoroutine(TransitionToScene());
    }

    private IEnumerator TransitionToScene()
    {
        // Optionally, you can add transition effects here
        // For example, you could fade out the screen, display a loading message, etc.

        Debug.Log("Starting transition to " + targetSceneName);

        // Wait for the specified delay
        yield return new WaitForSeconds(transitionDelay);

        // Load the target scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);

        // Optionally, you can wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log("Transition to " + targetSceneName + " complete.");
    }
}

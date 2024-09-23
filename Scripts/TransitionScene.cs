using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionScene : MonoBehaviour
{
    public float transitionDelay = 3f; // Delay before loading the next scene

    void Start()
    {
        StartCoroutine(LoadTargetSceneAfterDelay());
    }

    IEnumerator LoadTargetSceneAfterDelay()
    {
        // Get the target scene name that was stored in PlayerPrefs
        string targetScene = PlayerPrefs.GetString("TargetScene");

        // Wait for the delay
        yield return new WaitForSeconds(transitionDelay);

        // Load the target scene (QuizScene)
        SceneManager.LoadScene(targetScene);
    }
}

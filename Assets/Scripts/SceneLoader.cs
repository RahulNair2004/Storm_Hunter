using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Static method to handle transition between scenes
    public static void TransitionTo(string sceneName)
    {
        // Load the transition scene first
        SceneManager.LoadScene("TransitionScene");

        // Store the target scene name for the transition scene to load later
        PlayerPrefs.SetString("TargetScene", sceneName);
    }
}

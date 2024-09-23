using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform spawnPoint; // Reference to the spawn point in the scene
    public GameObject player; // Reference to the player GameObject

    private void Start()
    {
        // Set the previous scene when the game starts or when this script is initialized
        SceneManagerHelper.SetPreviousScene();
    }

    private void Update()
    {
        // Check for the "R" key to restart the game
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // Check for the "Escape" key to return to the previous scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToPreviousScene();
        }
    }

    private void RestartGame()
    {
        // Save the player's position before restarting
        PlayerPrefs.SetFloat("SavedPlayerPosX", spawnPoint.position.x);
        PlayerPrefs.SetFloat("SavedPlayerPosY", spawnPoint.position.y);
        PlayerPrefs.SetFloat("SavedPlayerPosZ", spawnPoint.position.z);
        PlayerPrefs.Save(); // Ensure the data is saved

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ReturnToPreviousScene()
    {
        // Load the previous scene if it exists
        if (!string.IsNullOrEmpty(SceneManagerHelper.previousSceneName))
        {
            SceneManager.LoadScene(SceneManagerHelper.previousSceneName);
        }
        else
        {
            Debug.LogWarning("Previous scene name is not set.");
        }
    }
}

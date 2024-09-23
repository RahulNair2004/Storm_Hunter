using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.SceneManagement; // Import the SceneManager namespace
using System.Collections; // Import for Coroutine

public class ScoreTrigger : MonoBehaviour
{
    // This will store the score
    public int score = 0;
    public int targetScore = 15; // Target score to change the scene
    public float waitTime = 3f; // Time to wait before transitioning to the "Game" scene

    // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Initialize the score text display
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Increase the score by 1
            score++;

            // Update the score text display
            UpdateScoreText();

            // Optionally, you can print the score to the console for debugging
            Debug.Log("Score: " + score);

            // Check if the score has reached the target score
            if (score >= targetScore)
            {
                // Start the coroutine to handle the transition
                StartCoroutine(HandleTransition());
            }
        }
    }

    private void UpdateScoreText()
    {
        // Update the text to display the current score
        if (scoreText != null)
        {
            scoreText.text = "" + score;
        }
    }

    private IEnumerator HandleTransition()
    {
        Debug.Log("Loading Transition Scene...");
        // Load the transition scene asynchronously
        AsyncOperation transitionSceneLoad = SceneManager.LoadSceneAsync("Transition Scene 1");

        // Wait until the transition scene is fully loaded
        while (!transitionSceneLoad.isDone)
        {
            yield return null;
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(waitTime);

        Debug.Log("Loading Game Scene...");
        // Load the game scene asynchronously
        AsyncOperation gameSceneLoad = SceneManager.LoadSceneAsync("Game");

        // Optionally, you can wait until the game scene is fully loaded
        while (!gameSceneLoad.isDone)
        {
            yield return null;
        }
    }
}

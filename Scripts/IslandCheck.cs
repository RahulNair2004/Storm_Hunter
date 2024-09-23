using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using System.Collections;
using TMPro; // For TextMeshPro

public class IslandCheck : MonoBehaviour
{
    public GameObject playerShip; // Reference to the player ship
    public GameObject island; // Reference to the island (has SphereCollider)
    public CanvasGroup winPanel; // CanvasGroup for win UI panel
    public CanvasGroup losePanel; // CanvasGroup for lose UI panel
    public TextMeshProUGUI[] scoreTexts; // Array of TextMeshPro for displaying multiple scores
    public TextMeshProUGUI timeText; // TextMeshPro for displaying the remaining time
    public float fadeDuration = 1f; // Duration of fade-in and fade-out
    public float uiDisplayDuration = 5f; // Duration the UI is shown before transitioning to another scene

    private bool isTransitioning = false; // To prevent multiple transitions

    void Update()
    {
        float currentTime = float.Parse(timeText.text); // Assuming timeText contains a float for time

        // If time runs out and player hasn't won, display lose UI
        if (currentTime <= 0 && !isTransitioning)
        {
            TriggerLose(); // Lose condition when time reaches 0
        }
    }

    // This method is called when the player ship reaches the island (using a SphereCollider and OnTriggerEnter)
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player ship
        if (other.gameObject == playerShip)
        {
            // Loop through the scoreTexts array and check if any of the scores is 25
            foreach (TextMeshProUGUI scoreText in scoreTexts)
            {
                int currentScore = int.Parse(scoreText.text); // Parse the score from each scoreText

                // If any scoreText has a score of exactly 25 and time is remaining
                if (currentScore == 25 && float.Parse(timeText.text) > 0)
                {
                    TriggerWin();
                    return; // Exit after triggering the win
                }
            }
        }
    }

    void TriggerWin()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            StartCoroutine(FadeUI(winPanel, true)); // Fade in the win UI
            Debug.Log("Game Won!");
            StartCoroutine(WaitAndTransition(uiDisplayDuration, "Main Menu"));
        }
    }

    void TriggerLose()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            StartCoroutine(FadeUI(losePanel, true)); // Fade in the lose UI
            Debug.Log("Game Lost!");
            StartCoroutine(WaitAndTransition(uiDisplayDuration, "Main Menu"));
        }
    }

    IEnumerator WaitAndTransition(float duration, string sceneName)
    {
        // Wait for the specified duration before transitioning to the main menu
        yield return new WaitForSeconds(duration);

        // Fade out the current UI
        StartCoroutine(FadeUI(winPanel, false));
        StartCoroutine(FadeUI(losePanel, false));

        // Wait for the fade-out to complete before loading the next scene
        yield return new WaitForSeconds(fadeDuration);

        // Load the specified scene (e.g., MainMenu)
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeUI(CanvasGroup canvasGroup, bool fadeIn)
    {
        float startAlpha = fadeIn ? 0 : 1;
        float endAlpha = fadeIn ? 1 : 0;
        float time = 0f;

        // Set the initial alpha
        canvasGroup.alpha = startAlpha;

        while (time < fadeDuration)
        {
            // Lerp the alpha value between 0 and 1 over the duration
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            time += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final alpha value is set
        canvasGroup.alpha = endAlpha;

        // Disable the canvas group if faded out
        if (!fadeIn)
        {
            canvasGroup.gameObject.SetActive(false); // Optional: Disable the object when faded out
        }
    }
}

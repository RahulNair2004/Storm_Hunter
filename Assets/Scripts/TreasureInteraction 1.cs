using System.Collections;
using UnityEngine;
using UnityEngine.UI; // For UI Image
using TMPro; // For TextMeshPro

public class TreasureInteraction1 : MonoBehaviour
{
    public Image treasureImage; // Reference to the UI Image component
    public TextMeshProUGUI[] scoreTexts; // Array of TextMeshPro UI components
    public float fadeDuration = 1f; // Duration of the fade effect
    public float delayBeforeDestroy = 0.5f; // Small delay before destroying the object
    private bool playerNearTreasure = false;

    void Start()
    {
        if (treasureImage != null)
        {
            treasureImage.gameObject.SetActive(false); // Hide the image initially
            Color color = treasureImage.color;
            color.a = 0f; // Start with fully transparent image
            treasureImage.color = color;
        }

        // Initialize score text
        UpdateScoreTexts();
    }

    void Update()
    {
        if (playerNearTreasure)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Start fading out the image and destroy the object after the fade completes
                if (treasureImage != null)
                {
                    StartCoroutine(FadeOutAndDestroyObject());
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Hide the image and stop showing it when pressing "Escape"
                StartCoroutine(FadeOutImage());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player can trigger this
        {
            playerNearTreasure = true;
            if (treasureImage != null)
            {
                StartCoroutine(FadeInImage()); // Fade in the image
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearTreasure = false;
            if (treasureImage != null)
            {
                StartCoroutine(FadeOutImage()); // Fade out the image
            }
        }
    }

    IEnumerator FadeInImage()
    {
        treasureImage.gameObject.SetActive(true); // Ensure image is active
        Color color = treasureImage.color;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration); // Increase alpha
            treasureImage.color = color;
            yield return null;
        }
        color.a = 1f; // Ensure it's fully opaque
        treasureImage.color = color;
    }

    IEnumerator FadeOutImage()
    {
        Color color = treasureImage.color;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - (elapsedTime / fadeDuration)); // Decrease alpha
            treasureImage.color = color;
            yield return null;
        }
        color.a = 0f; // Ensure it's fully transparent
        treasureImage.color = color;
        treasureImage.gameObject.SetActive(false); // Hide the image after fade-out
    }

    // This coroutine fades out the image, waits, then destroys the object
    IEnumerator FadeOutAndDestroyObject()
    {
        yield return StartCoroutine(FadeOutImage()); // Wait for the image to fade out

        // Wait for a brief moment after the fade-out before destroying the object
        yield return new WaitForSeconds(delayBeforeDestroy);

        // Increase the score by 5 using the ScoreManager
        ScoreManager.AddScore(5);

        // Update all score texts in TextMeshPro
        UpdateScoreTexts();

        // Now destroy the treasure object after the delay
        Destroy(gameObject);
    }

    // Function to update score texts
    void UpdateScoreTexts()
    {
        foreach (var scoreText in scoreTexts)
        {
            if (scoreText != null)
            {
                scoreText.text = "X " + ScoreManager.score.ToString();
            }
        }
    }
}

// This class manages the global score
public static class ScoreManager
{
    public static int score = 0;

    public static void AddScore(int points)
    {
        score += points;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI; // For UI Image

public class TreasureInteraction : MonoBehaviour
{
    public Image treasureImage; // Reference to the UI Image component
    public string transitionSceneName = "TransitionScene"; // Name of the transition scene
    public string quizSceneName = "QuizScene"; // Name of the scene with the quiz

    public float fadeDuration = 1f; // Duration of the fade effect
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
    }

    void Update()
    {
        if (playerNearTreasure)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // This calls the SceneLoader to start the transition to the quiz scene
                SceneLoader.TransitionTo(quizSceneName);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Hide the image and stop showing it
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
        treasureImage.gameObject.SetActive(true);
        Color color = treasureImage.color;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
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
            color.a = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
            treasureImage.color = color;
            yield return null;
        }
        color.a = 0f; // Ensure it's fully transparent
        treasureImage.color = color;
        treasureImage.gameObject.SetActive(false);
    }
}

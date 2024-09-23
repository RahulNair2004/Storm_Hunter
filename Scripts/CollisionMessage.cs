using UnityEngine;
using TMPro; // For TextMeshPro
using System.Collections;

public class CollisionMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText; // For TextMeshPro, otherwise use UnityEngine.UI.Text for regular Text
    public string warningMessage = "You cannot cross!"; // The message to display
    public float messageDuration = 3f; // Time the message will stay on screen
    public float fadeDuration = 1f; // Duration for fade-in and fade-out

    private void Start()
    {
        // Ensure the message is fully transparent initially
        Color color = messageText.color;
        color.a = 0;
        messageText.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the ship has the "Player" tag
        {
            // Start coroutine to show and then hide the message
            StartCoroutine(ShowAndHideMessage());
        }
    }

    private IEnumerator ShowAndHideMessage()
    {
        // Fade in the message
        yield return StartCoroutine(FadeInMessage());

        // Wait for the duration the message is visible
        yield return new WaitForSeconds(messageDuration);

        // Fade out the message
        yield return StartCoroutine(FadeOutMessage());
    }

    private IEnumerator FadeInMessage()
    {
        float timer = 0f;
        Color color = messageText.color;

        messageText.text = warningMessage; // Set the message text

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, timer / fadeDuration); // Gradually increase the alpha from 0 to 1
            messageText.color = color;
            yield return null; // Wait for the next frame
        }

        // Ensure the alpha is set to 1 at the end
        color.a = 1;
        messageText.color = color;
    }

    private IEnumerator FadeOutMessage()
    {
        float timer = 0f;
        Color color = messageText.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, timer / fadeDuration); // Gradually decrease the alpha from 1 to 0
            messageText.color = color;
            yield return null; // Wait for the next frame
        }

        // Ensure the alpha is set to 0 at the end
        color.a = 0;
        messageText.color = color;

        // Clear the text after fading out
        messageText.text = "";
    }
}

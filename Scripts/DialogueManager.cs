using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;          // The panel or dialogue box UI element
    public TextMeshProUGUI dialogueText;      // TextMeshProUGUI component for displaying dialogues
    public string[] dialogues;                // Array to hold all the dialogues
    public float fadeDuration = 1f;           // Duration for the fade effect
    private int currentDialogueIndex = 0;
    private bool isDialogueComplete = false;

    void Start()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Ensure the dialogue panel is active at the start
        dialoguePanel.SetActive(true);
        ShowDialogue();
    }

    void Update()
    {
        // Check if player presses a key to move to the next dialogue (or use button event)
        if (Input.GetKeyDown(KeyCode.Space) && !isDialogueComplete)
        {
            NextDialogue();
        }
    }

    void ShowDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            StartCoroutine(FadeOutDialogueBox());
        }
    }

    void NextDialogue()
    {
        currentDialogueIndex++;

        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            isDialogueComplete = true;
            StartCoroutine(FadeOutDialogueBox());
        }
    }

    IEnumerator FadeOutDialogueBox()
    {
        // Fade out the dialogue box
        CanvasGroup canvasGroup = dialoguePanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = dialoguePanel.AddComponent<CanvasGroup>();
        }

        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, timeElapsed / fadeDuration);
            yield return null;
        }

        // Disable dialogue box and resume game
        dialoguePanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
}

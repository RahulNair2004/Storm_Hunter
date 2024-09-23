using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Required to access Button components
using System;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;         // Reference to the dialogue panel (UI)
    public TextMeshProUGUI textComponent;    // TextMeshPro component for dialogue text
    public Button continueButton;            // Continue button UI element
    public string[] lines;                   // Array of dialogue lines
    public float textSpeed;                  // Speed of text typing

    private int index;                       // Current dialogue line index
    private bool isTyping = false;           // Flag to check if typing is in progress

    // Start is called before the first frame update
    void Start()
    {
        // Set initial text to empty
        textComponent.text = string.Empty;

        // Show the continue button initially
        continueButton.gameObject.SetActive(true);

        // Freeze the game
        Time.timeScale = 0f;

        // Add listener to Continue Button
        continueButton.onClick.AddListener(NextLine);

        // Start the dialogue
        StartDialogue();
    }

    // Start the dialogue sequence
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    // Coroutine to type out each line
    IEnumerator TypeLine()
    {
        isTyping = true;  // Indicate that typing is in progress
        textComponent.text = string.Empty;  // Clear existing text
        continueButton.interactable = false;  // Disable the button while typing

        foreach (Char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);  // Use WaitForSecondsRealtime to ignore Time.timeScale
        }

        isTyping = false;  // Typing is complete
        continueButton.interactable = true;  // Enable the button after the line is typed
    }

    // Move to the next dialogue line
    public void NextLine()
    {
        if (isTyping) return;  // Prevent skipping while typing

        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            // End of the dialogue
            EndDialogue();
        }
    }

    // End the dialogue and resume the game
    void EndDialogue()
    {
        // Resume the game
        Time.timeScale = 1f;

        // Hide the dialogue panel
        dialoguePanel.SetActive(false);
    }
}

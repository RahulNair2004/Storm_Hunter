using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro component
    public GameObject timeOutPanel; // Reference to the UI panel to be displayed when time runs out
    public float timeRemaining = 360f; // 6 minutes (in seconds)
    private bool timerIsRunning = false;

    void Start()
    {
        // Start the timer at the beginning of the game
        timerIsRunning = true;
        UpdateTimerText(); // Initialize the timer display
        timeOutPanel.SetActive(false); // Ensure the panel is hidden at the start
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Decrease the timer
                UpdateTimerText(); // Update the timer display
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false; // Stop the timer when it reaches 0
                UpdateTimerText(); // Final update to show 00:00
                OnTimerEnd(); // Call when timer reaches 0
            }
        }
    }

    // Method to update the TextMeshPro timer display
    void UpdateTimerText()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60); // Calculate minutes
        float seconds = Mathf.FloorToInt(timeRemaining % 60); // Calculate seconds

        // Format the string as MM:SS
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // This method will be called when the timer ends
    void OnTimerEnd()
    {
        Debug.Log("Timer has ended!");
        timeOutPanel.SetActive(true); // Show the time-out UI panel
        Time.timeScale = 0; // Freeze the game
    }

    // Optional: You can add a method to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        timeOutPanel.SetActive(false); // Hide the time-out UI panel
    }
}

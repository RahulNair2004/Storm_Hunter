using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static bool timerStarted = false; // If the timer has started
    public static float timeRemaining = 300f; // 5 minutes in seconds
    public static bool gameWon = false; // Tracks if the game has been won

    void Update()
    {
        if (timerStarted && !gameWon)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                // Trigger lose condition handled in IslandCheck
            }
        }
    }

    public static void StartTimer()
    {
        timerStarted = true;
    }
}

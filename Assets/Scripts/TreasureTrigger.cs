using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureTrigger : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform

    private void OnTriggerStay(Collider other)
    {
        // Check if the player is within the trigger zone and press the 'E' key
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Save the player's current position
            PlayerPrefs.SetFloat("SavedPlayerPosX", playerTransform.position.x);
            PlayerPrefs.SetFloat("SavedPlayerPosY", playerTransform.position.y);
            PlayerPrefs.SetFloat("SavedPlayerPosZ", playerTransform.position.z);
            PlayerPrefs.Save(); // Ensure the data is saved

            // Destroy the treasure object
            Destroy(gameObject);

            // Transition to the quiz scene
            SceneManager.LoadScene("QuizScene");
        }
    }
}

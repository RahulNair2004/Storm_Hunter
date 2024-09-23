using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionRestorer : MonoBehaviour
{
    public Transform playerTransform; // Assign the player's Transform in the Inspector
    public Transform spawnPoint; // Assign the desired spawn point in the Inspector

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            // Restore the player's position if saved
            if (PlayerPrefs.HasKey("SavedPlayerPosX"))
            {
                float posX = PlayerPrefs.GetFloat("SavedPlayerPosX");
                float posY = PlayerPrefs.GetFloat("SavedPlayerPosY");
                float posZ = PlayerPrefs.GetFloat("SavedPlayerPosZ");
                playerTransform.position = new Vector3(posX, posY, posZ);

                // Clear the saved position
                PlayerPrefs.DeleteKey("SavedPlayerPosX");
                PlayerPrefs.DeleteKey("SavedPlayerPosY");
                PlayerPrefs.DeleteKey("SavedPlayerPosZ");
            }
            else
            {
                // Set to the spawn point if no saved position is found
                playerTransform.position = spawnPoint.position;
            }
        }
    }
}

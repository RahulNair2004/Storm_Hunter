using UnityEngine;

public class DestroyOnInteraction : MonoBehaviour
{
    private bool isPlayerNear = false; // To track if the player is near the object

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the box collider
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the box collider
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void Update()
    {
        // Check if the player is near and presses the "E" key
        if (isPlayerNear && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(gameObject); // Destroy this game object
        }
    }
}

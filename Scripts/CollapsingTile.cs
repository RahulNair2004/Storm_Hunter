using UnityEngine;
using System.Collections;

public class CollapsingTile : MonoBehaviour
{
    public float collapseDelay = 1f;  // Delay before the tile collapses
    private bool playerOnTile = false;  // To track if the player is on the tile
    private Rigidbody rb;  // For 3D physics

    void Start()
    {
        // Add Rigidbody for physics-based interaction
        rb = gameObject.AddComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component could not be added to the tile.");
        }
        else
        {
            rb.isKinematic = true;  // Make it kinematic initially (not affected by physics)
            Debug.Log("Rigidbody successfully added to the tile.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnTile = true;
            StartCoroutine(CollapseAfterDelay(collapseDelay));  // Start coroutine to handle collapse
        }
    }

    IEnumerator CollapseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified delay
        CollapseTile();  // Call the method to collapse the tile
    }

    void CollapseTile()
    {
        if (playerOnTile)
        {
            if (rb != null)
            {
                rb.isKinematic = false;  // Enable physics so the tile "falls"
                Debug.Log("Tile is collapsing.");
            }
            else
            {
                Debug.LogError("Rigidbody is not assigned.");
            }
        }
    }
}

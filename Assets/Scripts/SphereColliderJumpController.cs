using UnityEngine;

public class SphereColliderJumpController : MonoBehaviour
{
    public float jumpForce = 10f; // Force applied when jumping
    public SphereCollider sphereCollider; // Reference to the SphereCollider on the obstacle

    private Rigidbody rb;
    private bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Ensure the SphereCollider is assigned
        if (sphereCollider == null)
        {
            Debug.LogError("SphereCollider not assigned!");
        }
    }

    private void Update()
    {
        // Use the spacebar to jump only if the player is within the SphereCollider's range
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the SphereCollider
        if (other == sphereCollider)
        {
            canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the SphereCollider
        if (other == sphereCollider)
        {
            canJump = false;
        }
    }

    private void Jump()
    {
        // Apply a force to the Rigidbody to make the player jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

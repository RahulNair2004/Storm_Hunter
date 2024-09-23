using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float moveForce = 10f;   // Force applied for movement
    public float jumpForce = 10f;   // Force applied for jumping
    public float groundCheckDistance = 0.2f; // Distance to check if grounded
    public LayerMask groundLayer;   // Layer for ground detection

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Handle movement input
        HandleMovement();

        // Handle jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Check if the sphere is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // -1 (left) to 1 (right)
        float moveVertical = Input.GetAxis("Vertical"); // -1 (backward) to 1 (forward)

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(move * moveForce);
    }

    void Jump()
    {
        // Apply force upwards to make the sphere jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

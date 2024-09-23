using UnityEngine;

public class ImageController1 : MonoBehaviour
{
    private Animator animator;
    private bool isUp = false; // Tracks whether the image is up or down

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the Image GameObject
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the T key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Toggle the isUp state
            isUp = !isUp;

            // Set the "IsUp" parameter in the Animator based on the new state
            animator.SetBool("IsUp", isUp);
        }
    }
}

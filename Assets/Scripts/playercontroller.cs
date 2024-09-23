using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Use the spacebar to jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Detect if the player can jump by checking if they're touching the ground
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    // Disable jumping when the player leaves the ground
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("QuizScene");
        }
    }
}
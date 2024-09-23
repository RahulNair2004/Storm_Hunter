using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] float thrust;
    [SerializeField] float turningSpeed;

    [SerializeField] float motorFoamMultiplier;
    [SerializeField] float motorFoamBase;
    [SerializeField] float frontFoamMultiplier;

    [SerializeField] float boostMultiplier = 2f; // How much faster the boost is
    [SerializeField] float boostDuration = 3f; // Duration of the boost in seconds
    [SerializeField] float boostCooldown = 5f; // Cooldown period after boost

    private bool isBoosting = false;
    private bool boostAvailable = true;

    private Rigidbody rb;
    private ParticleSystem.EmissionModule motor, front;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Get particle systems for foam effects
        motor = transform.GetChild(0).GetComponent<ParticleSystem>().emission;
        front = transform.GetChild(1).GetComponent<ParticleSystem>().emission;
    }

    void FixedUpdate()
    {
        // Get input from keyboard
        float horizontalInput = 0f;
        float throttleInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f; // Turn left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f; // Turn right
        }

        if (Input.GetKey(KeyCode.W))
        {
            throttleInput = 1f; // Move forward
        }
        else if (Input.GetKey(KeyCode.S))
        {
            throttleInput = -1f; // Move backward
        }

        // Check for boost input (Shift + any movement key)
        if (boostAvailable && !isBoosting && Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(throttleInput) > 0.1f)
        {
            StartCoroutine(ActivateBoost());
        }

        // Apply turning
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + horizontalInput * turningSpeed * Time.fixedDeltaTime, 0);
        }

        // Apply throttle (forward or backward movement)
        if (Mathf.Abs(throttleInput) > 0.1f)
        {
            float currentThrust = isBoosting ? thrust * boostMultiplier : thrust;
            rb.AddRelativeForce(Vector3.forward * currentThrust * Time.fixedDeltaTime * throttleInput);
        }

        // Apply foam effects based on throttle and boat speed
        motor.rateOverTime = motorFoamMultiplier * throttleInput + motorFoamBase;
        front.rateOverTime = frontFoamMultiplier * rb.velocity.magnitude;
    }

    // Coroutine to handle boost activation, duration, and cooldown
    IEnumerator ActivateBoost()
    {
        isBoosting = true; // Start boosting
        boostAvailable = false; // Disable further boosts during cooldown

        yield return new WaitForSeconds(boostDuration); // Boost lasts for the specified duration

        isBoosting = false; // Stop boosting

        yield return new WaitForSeconds(boostCooldown); // Wait for cooldown

        boostAvailable = true; // Boost is available again
    }
}

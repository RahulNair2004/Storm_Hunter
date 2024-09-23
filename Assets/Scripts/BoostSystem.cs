using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoostSystem : MonoBehaviour
{
    public Rigidbody shipRigidbody;         // Ship's Rigidbody
    public TextMeshProUGUI speedText;       // Speed display (from previous script)
    public Slider boostSlider;              // UI Slider for boost cooldown

    [SerializeField] float boostMultiplier = 2f; // Speed multiplier during boost
    [SerializeField] float boostDuration = 3f;   // Duration of the boost
    [SerializeField] float cooldownDuration = 7f;// Cooldown duration for the boost
    [SerializeField] float normalSpeed = 10f;    // Normal thrust speed
    [SerializeField] float smoothingSpeed = 0.1f;// Smoothing for speed display

    private float displayedSpeed = 0f;
    private bool isBoosting = false;
    private float boostTimer = 0f;
    private float cooldownTimer = 0f;
    private bool canBoost = true; // Check if boost is ready to use

    void Start()
    {
        boostSlider.value = 1f; // Boost is initially full
    }

    void Update()
    {
        HandleBoost();
        UpdateSpeedDisplay();
        UpdateBoostUI();
    }

    void HandleBoost()
    {
        // Handle boost activation
        if (canBoost && Input.GetKey(KeyCode.LeftShift))
        {
            isBoosting = true;
            boostTimer = boostDuration;
            canBoost = false;
        }

        // Boost logic
        if (isBoosting)
        {
            boostTimer -= Time.deltaTime;
            shipRigidbody.velocity += shipRigidbody.transform.forward * boostMultiplier * Time.deltaTime;

            if (boostTimer <= 0f)
            {
                isBoosting = false;
                cooldownTimer = cooldownDuration;
            }
        }
        else if (!canBoost)
        {
            // Handle cooldown
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                canBoost = true;
                boostSlider.value = 1f;
            }
        }
    }

    void UpdateSpeedDisplay()
    {
        // Get the actual speed of the ship in km/h
        float actualSpeed = shipRigidbody.velocity.magnitude * 3.6f;

        // Smooth the speed display
        displayedSpeed = Mathf.Lerp(displayedSpeed, actualSpeed, smoothingSpeed * Time.deltaTime);

        // Update the speed text to display the smoothed speed
        speedText.text = displayedSpeed.ToString("0") + " km/h";
    }

    void UpdateBoostUI()
    {
        // If boosting, decrease the boost slider over time
        if (isBoosting)
        {
            boostSlider.value = Mathf.Clamp(boostTimer / boostDuration, 0, 1);
        }
        // If on cooldown, fill the boost slider over time
        else if (!canBoost)
        {
            boostSlider.value = Mathf.Clamp01(1f - (cooldownTimer / cooldownDuration));
        }
    }
}

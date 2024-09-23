using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class Speedometer : MonoBehaviour
{
    public Rigidbody shipRigidbody;   // The Rigidbody of the ship
    public TextMeshProUGUI speedText; // TextMeshProUGUI element to display speed
    public float smoothingSpeed = 0.1f; // How quickly to update the speed display

    private float displayedSpeed = 0f; // Current displayed speed (for smoothing)

    void Update()
    {
        // Get the actual speed of the ship (in m/s, then convert to km/h)
        float actualSpeed = shipRigidbody.velocity.magnitude * 3.6f; 

        // Smooth the speed display by interpolating between the current displayed speed and actual speed
        displayedSpeed = Mathf.Lerp(displayedSpeed, actualSpeed, smoothingSpeed * Time.deltaTime);

        // Update the speed text to display the smoothed speed (rounded)
        speedText.text = displayedSpeed.ToString("0") + " km/h"; // Display speed as whole number
    }
}

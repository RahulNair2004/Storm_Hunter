using System.Collections;
using UnityEngine;

public class ThunderEffect : MonoBehaviour
{
    public Light[] lightningLights;  // Array of Light components for different lightning effects
    public float minWaitTime = 2f;  // Minimum time between lightning flashes
    public float maxWaitTime = 5f;  // Maximum time between lightning flashes
    public float flashDuration = 0.1f;  // Duration for each lightning flash

    void Start()
    {
        // Start the lightning coroutine
        StartCoroutine(ThunderRoutine());
    }

    // Coroutine to manage the lightning effect
    IEnumerator ThunderRoutine()
    {
        while (true)  // This will run indefinitely
        {
            // Wait for a random amount of time between lightning flashes
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);

            // Randomly select a lightning light from the array
            Light selectedLight = lightningLights[Random.Range(0, lightningLights.Length)];

            // Flash the selected light to simulate lightning
            selectedLight.enabled = true;  // Turn on the light
            yield return new WaitForSeconds(flashDuration);  // Flash duration
            selectedLight.enabled = false;  // Turn off the light
        }
    }
}

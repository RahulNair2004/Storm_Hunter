using System.Collections;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    public Camera mainCamera;       // Reference to the camera
    public Color[] colors;          // Array of colors to cycle through
    public float changeInterval = 2f;  // Time interval between transitions
    
    private int currentColorIndex = 0;
    private int nextColorIndex = 1;
    private float transitionProgress = 0f;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // Get the main camera if not assigned
        }
        
        StartCoroutine(SmoothChangeBackgroundColor());
    }

    IEnumerator SmoothChangeBackgroundColor()
    {
        while (true)
        {
            // Gradually transition the color
            while (transitionProgress < 1f)
            {
                transitionProgress += Time.deltaTime / changeInterval;
                mainCamera.backgroundColor = Color.Lerp(colors[currentColorIndex], colors[nextColorIndex], transitionProgress);
                yield return null;
            }

            // Reset transition progress and update the color indices
            transitionProgress = 0f;
            currentColorIndex = nextColorIndex;
            nextColorIndex = (nextColorIndex + 1) % colors.Length;

            // Wait for the interval before starting the next transition
            yield return new WaitForSeconds(changeInterval);
        }
    }
}

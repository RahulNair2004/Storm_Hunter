using System.Collections;
using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    public Color[] colors;          // Array of colors to cycle through
    public float changeInterval = 2f;  // Time interval between transitions
    
    private int currentColorIndex = 0;
    private int nextColorIndex = 1;
    private float transitionProgress = 0f;
    private Renderer cubeRenderer;

    void Start()
    {
        // Get the Renderer component of the cube
        cubeRenderer = GetComponent<Renderer>();

        if (cubeRenderer == null)
        {
            Debug.LogError("Cube Renderer not found!");
            return;
        }
        
        // Start the smooth color change coroutine
        StartCoroutine(SmoothChangeCubeColor());
    }

    IEnumerator SmoothChangeCubeColor()
    {
        while (true)
        {
            // Gradually transition the color
            while (transitionProgress < 1f)
            {
                transitionProgress += Time.deltaTime / changeInterval;
                cubeRenderer.material.color = Color.Lerp(colors[currentColorIndex], colors[nextColorIndex], transitionProgress);
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

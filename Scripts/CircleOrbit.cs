using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // The island (or the center point of the island)
    public float orbitDuration = 10f; // Time it takes for one complete orbit
    public float orbitDistance = 50f; // Distance from the target
    public float orbitHeight = 20f; // Height above the target

    private Vector3 offset; // Offset from the target position

    void Start()
    {
        // Calculate the initial offset based on orbit distance and height
        offset = new Vector3(orbitDistance, orbitHeight, 0);
    }

    void Update()
    {
        // Calculate the angle to rotate the camera around the target over time
        float angle = (Time.time / orbitDuration) * 360f;

        // Calculate the new position for the camera based on the angle
        Vector3 newPosition = target.position + Quaternion.Euler(0, angle, 0) * offset;

        // Update the camera position
        transform.position = newPosition;

        // Make the camera look at the target (island)
        transform.LookAt(target);
    }
}

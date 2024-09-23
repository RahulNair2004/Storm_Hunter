
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target (ship) the camera should follow
    public Vector3 offset;   // Offset from the target

    void LateUpdate()
    {
        // Update the camera position to follow the target
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}

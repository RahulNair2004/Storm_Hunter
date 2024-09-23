using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1; // Assign your first camera in the Unity inspector
    public Camera camera2; // Assign your second camera in the Unity inspector
    public Camera camera3; // Assign your third camera in the Unity inspector

    private int currentCameraIndex = 0; // To keep track of which camera is active

    void Start()
    {
        // Ensure only camera1 is active at the start
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
    }

    void Update()
    {
        // Detect when the "Tab" button is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Increment the camera index and loop back when it exceeds 2 (because we have 3 cameras)
            currentCameraIndex = (currentCameraIndex + 1) % 3;

            // Switch between cameras based on the currentCameraIndex
            if (currentCameraIndex == 0)
            {
                camera1.enabled = true;
                camera2.enabled = false;
                camera3.enabled = false;
            }
            else if (currentCameraIndex == 1)
            {
                camera1.enabled = false;
                camera2.enabled = true;
                camera3.enabled = false;
            }
            else if (currentCameraIndex == 2)
            {
                camera1.enabled = false;
                camera2.enabled = false;
                camera3.enabled = true;
            }
        }
    }
}

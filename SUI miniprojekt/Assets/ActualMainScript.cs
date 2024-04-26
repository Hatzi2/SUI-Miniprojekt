using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualMainScript : MonoBehaviour
{
    public GameObject Lefthand;
    public GameObject RightHand;
    public GameObject viewPlane;
    public GameObject camera;
    public GameObject mainCamera;
    public GameObject child;

    private GameObject leftWrist;
    private GameObject rightWrist;
    private Vector3 rightPosition;
    private Vector3 leftPosition;

    public float minimalDistance;
    private float time = 0;
    public float fixedDistance = 10.0f; // Set this to the desired fixed distance

    // Update is called once per frame
    void Update()
    {
        // Find the wrists
        leftWrist = GameObject.Find("L_Wrist");
        rightWrist = GameObject.Find("R_Wrist");

        // Get positions
        leftPosition = leftWrist.transform.position;
        rightPosition = rightWrist.transform.position;
        Vector3 cameraPosition = camera.transform.position;
        Vector3 mainCameraPosition = mainCamera.transform.position;

        // Calculate distance
        float distance = Vector3.Distance(leftPosition, rightPosition);

        // If both hands are active
        if (Lefthand.activeSelf && RightHand.activeSelf)
        {
            time += Time.deltaTime;

            camera.transform.localPosition = new Vector3(0, 0, distance * 15);

            // Activate view plane
            viewPlane.SetActive(true);

            // Map the quad corners to the hand positions
            Vector3 bottomLeft = new Vector3(leftPosition.x - 1, leftPosition.y, leftPosition.z + 1);
            Vector3 topRight = new Vector3(rightPosition.x + 1, rightPosition.y, rightPosition.z + 1);
            Vector3 center = (bottomLeft + topRight) / 2;

            // Position the quad at a fixed distance from the mainCamera
            Vector3 directionFromCamera = (center - mainCamera.transform.position).normalized;
            viewPlane.transform.position = mainCamera.transform.position + directionFromCamera * fixedDistance;

            // Scale the quad by the distance of the wrists
            viewPlane.transform.localScale = new Vector3(distance, distance, distance);

            // Make the quad always face the mainCamera
            viewPlane.transform.LookAt(camera.transform.position);
        }
        else
        {
            // Deactivate view plane
            viewPlane.SetActive(false);

            // If time is greater than 0.3
            if (time > 0.3)
            {
                // Teleport the main camera to the position of the other camera
                mainCamera.transform.position = camera.transform.position;
                time = 0;
            }

            // Reset the camera's position
            camera.transform.position = mainCameraPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinalMainScript : MonoBehaviour
{
    public GameObject Lefthand;
    public GameObject RightHand;
    public GameObject viewPlane;
    public GameObject camera;
    public GameObject XROrigin;
    public GameObject child;
    public GameObject mainCamera;
    public int quadX = 0;
    public int quadY = 0;
    public int quadZ = 0;
    private GameObject leftWrist;
    private GameObject rightWrist;
    private Vector3 rightPosition;
    private Vector3 leftPosition;
    private float time = 0;
    private Vector3 moveDirection; // Declare moveDirection as a member variable
    private Vector3 planeLocation;
    private float moveSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        leftWrist = GameObject.Find("L_Wrist");
        rightWrist = GameObject.Find("R_Wrist");

        // Get positions
        leftPosition = leftWrist.transform.position;
        rightPosition = rightWrist.transform.position;
        Vector3 cameraPosition = camera.transform.position;
        Vector3 XROriginPosition = XROrigin.transform.position;

        Vector3 mainCameraPosition = mainCamera.transform.position;

        // Calculate distance
        float distance = Vector3.Distance(leftPosition, rightPosition);
        Vector3 bottomLeft = new Vector3(leftPosition.x, leftPosition.y, leftPosition.z);
        Vector3 topRight = new Vector3(rightPosition.x, rightPosition.y, rightPosition.z);

        Vector3 center = (bottomLeft + topRight) / 2;
        moveDirection = center - mainCameraPosition; // Assign value to moveDirection
        planeLocation = moveDirection*5;
        planeLocation = new Vector3(planeLocation.x+ 0.1f, planeLocation.y+0.2f, planeLocation.z);


        if (Lefthand.activeSelf && RightHand.activeSelf)
        {
            viewPlane.SetActive(true);
            time += Time.deltaTime;
            
            viewPlane.transform.localPosition = mainCameraPosition+planeLocation;
            viewPlane.transform.LookAt(mainCamera.transform.position);
            viewPlane.transform.localScale = new Vector3(distance, distance, distance);



            camera.transform.LookAt(camera.transform.position + moveDirection);
            //camera.transform.localPosition = moveDirection*distance*20; This somewat worked

            // Transform moveDirection to local space
            Vector3 localMoveDirection = camera.transform.InverseTransformDirection(moveDirection);

            // Set the local position of the camera along its local z-axis
            camera.transform.localPosition = new Vector3(0, 0, localMoveDirection.z * distance * 20);




        }
        else
        {
            // Deactivate view plane
            viewPlane.SetActive(false);

            // If time is greater than 0.3
            if (time > 0.3)
            {
                
                // Teleport the main camera to the position of the other camera
                XROrigin.transform.position = cameraPosition;
                time = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Draw line representing moveDirection
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(mainCamera.transform.position, mainCamera.transform.position + planeLocation);
    }
}
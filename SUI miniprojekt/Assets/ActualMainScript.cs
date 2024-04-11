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

    private GameObject leftWrist;
    private GameObject rightWrist;
    private Vector3 rightPosition;
    private Vector3 leftPosition;

    private Vector3 mainCameraPosition;

    public float minimalDistance;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        leftWrist = GameObject.Find("L_Wrist");
        rightWrist = GameObject.Find("R_Wrist");
        leftPosition = leftWrist.transform.position;
        rightPosition = rightWrist.transform.position;
        Vector3 cameraPosition = camera.transform.position;
        Vector3 mainCameraPosition = mainCamera.transform.position;


        float distance = Vector3.Distance(leftPosition, rightPosition);
        float time

        if (Lefthand.activeSelf && RightHand.activeSelf) {

            viewPlane.transform.localScale = new Vector3 (distance, distance, distance);
            camera.transform.localPosition = new Vector3(0, 0, distance*5);
            viewPlane.SetActive(true);
            

            Debug.Log(distance);
        }
        else
        {
            viewPlane.SetActive(false);
            mainCamera.transform.position = cameraPosition;
        }
    }

}

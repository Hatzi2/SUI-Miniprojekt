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

        if (Lefthand.activeSelf && RightHand.activeSelf)
        {
            
            camera.transform.parent = null;

            time += Time.deltaTime;
            viewPlane.transform.localScale = new Vector3(distance, distance, distance);
            camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y, distance * 5);

            viewPlane.SetActive(true);
            


        }
        else
        {
            camera.transform.position = mainCameraPosition;
            viewPlane.SetActive(false);
            if (time > 0.3)
            {


                mainCamera.transform.position = cameraPosition;
                time = 0;

                
                camera.transform.parent = child.transform.parent;

            }
            mainCameraPosition = mainCamera.transform.position;
        }
    }

}   
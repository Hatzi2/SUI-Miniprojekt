using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straightup : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

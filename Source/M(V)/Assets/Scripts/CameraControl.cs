using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * By: Jeremy Bost
 * 
 * Attach to Camera object
 */


public class CameraControl : MonoBehaviour
{
    public float sensitivityCamera = 5.0f;

    Transform ship;
    
    // Use this for initialization
    void Start()
    {
        ship = transform.parent.Find("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        

        float deltaX = -Input.GetAxis("Mouse Y") * sensitivityCamera;
        float deltaY = Input.GetAxis("Mouse X") * sensitivityCamera;

        transform.RotateAround(ship.position, transform.up, deltaY);
        transform.RotateAround(ship.position, transform.right, deltaX);
    }

    void LateUpdate()
    {
        transform.LookAt(ship);
    }
}


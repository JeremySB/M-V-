using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * By: Jeremy Bost
 * 
 * Attach to Camera object
 */


public class MouseLook : MonoBehaviour
{
    public float sensitivityCamera = 5.0f;

    Transform ship;
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ship = transform.parent.Find("Ship");

        float deltaX = -Input.GetAxis("Mouse Y") * sensitivityCamera;
        float deltaY = Input.GetAxis("Mouse X") * sensitivityCamera;

        transform.RotateAround(ship.position, ship.up, deltaY);
        transform.RotateAround(ship.position, transform.right, deltaX);
    }
}

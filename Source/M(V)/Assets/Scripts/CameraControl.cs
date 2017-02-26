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
    public float maxVertical = 80.0f;
    public float minVertical = -80.0f;
	public float heightAboveShip = 8f;
	public float distFromShip = 30f;
    public Transform ship;

    private Renderer shipRenderer;

    // Use this for initialization
    void Start()
    {
        shipRenderer = ship.GetComponent<Renderer>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float deltaX = Input.GetAxis("Pitch") * sensitivityCamera;
        float deltaY = Input.GetAxis("Yaw") * sensitivityCamera;

        transform.Rotate(deltaX, deltaY, 0);

        Vector3 cameraCenter = ship.position + ship.up * heightAboveShip;

        // look for objects in the way of camera
        RaycastHit hit;
        float calcDistFromShip = distFromShip;

        // check for objects between ship and camera's center point
        if (Physics.Raycast(ship.position, ship.up, out hit) && hit.transform.tag != "Player")
        {
            cameraCenter = ship.position + ship.up * Mathf.Min(hit.distance, heightAboveShip);
        }

        // check for objects between point camera rotates around and actual camera
        if (Physics.SphereCast(cameraCenter, 1.5f, -transform.forward, out hit, 400))
        {
            calcDistFromShip = Mathf.Min(hit.distance - 0.1f, distFromShip);

            if(calcDistFromShip < 5)
            {
                shipRenderer.enabled = false;
            } else
            {
                shipRenderer.enabled = true;
            }
        }

        transform.position = cameraCenter - (transform.forward * calcDistFromShip);
        transform.rotation = Quaternion.LookRotation(transform.forward, ship.up);
    }
}


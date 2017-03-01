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
    private MenuManager menu;

    // Use this for initialization
    void Start()
    {
        shipRenderer = ship.GetComponent<Renderer>();
        menu = FindObjectOfType<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(menu.IsMenuShown);
        if(menu.IsMenuShown)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void LateUpdate()
    {
        if (menu.IsMenuShown) return;

        float deltaX = Input.GetAxis("Pitch") * sensitivityCamera;
        float deltaY = Input.GetAxis("Yaw") * sensitivityCamera;

        transform.Rotate(deltaX, deltaY, 0);

        Vector3 cameraCenter = ship.position + ship.up * heightAboveShip;

        // look for objects in the way of camera
        RaycastHit hit;
        float calcDistFromShip = distFromShip;

        // check for objects between ship and camera's center point
		if (Physics.Raycast(ship.position, ship.up, out hit, heightAboveShip+3) && hit.transform.tag != "Player")
        {
			cameraCenter = ship.position + ship.up * (hit.distance - 3);
        }

        // check for objects between point camera rotates around and actual camera
		if (Physics.SphereCast(cameraCenter, 1.5f, -transform.forward, out hit, distFromShip))
        {
			calcDistFromShip = hit.distance - 0.3f;//Mathf.Min(hit.distance - 0.1f, distFromShip);
        }

        if (calcDistFromShip < 3)
        {
            shipRenderer.enabled = false;
        }
        else
        {
            shipRenderer.enabled = true;
        }

        Debug.DrawLine (ship.position, cameraCenter,Color.red);
		Debug.DrawLine (cameraCenter, cameraCenter - (transform.forward * calcDistFromShip), Color.cyan);
        transform.position = cameraCenter - (transform.forward * calcDistFromShip);
        transform.rotation = Quaternion.LookRotation(transform.forward, ship.up);
    }
}


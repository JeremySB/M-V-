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
	//public float rotationZ = 0f;
	public float distFromShip = 30f;
    Transform ship;
    
    // Use this for initialization
    void Start()
    {
        ship = transform.parent;
        //transform.localPosition = transform.localPosition + new Vector3(0, offset, 0);

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

        transform.position = (ship.position + ship.up * 10) - (transform.forward * distFromShip);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        transform.Translate(new Vector3(0, 0, 0));
    }
    /*void LateUpdate()
	{
		float oldRotationX = rotationX;
		float deltaX = -Input.GetAxis("Mouse Y") * sensitivityCamera;
		float deltaY = Input.GetAxis("Mouse X") * sensitivityCamera;

		rotationX += deltaX;
		rotationY += deltaY;

		Vector3 shipRot = ship.eulerAngles;
		Vector3 localRot = new Vector3 (-rotationX , -rotationY, 0);
		this.transform.eulerAngles = shipRot + localRot;

		Vector3 locAngle = new Vector3(-rotationY,rotationX, -shipRot.z);
		this.transform.position = (ship.position - (Vector3.Normalize (locAngle) * distFromShip));


	}*/

}


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
	public float sides = 90f;
    public float rotationX = 20f;
    public float rotationY = -10f;
	//public float rotationZ = 0f;
	public float distFromShip = 2000f;
    public float offset = 0.0f;
    Transform ship;
    
    // Use this for initialization
    void Start()
    {
        ship = transform.parent.parent.Find("Ship");
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

        //Vector3 shipAngles = ship.localEulerAngles;

        rotationX += -Input.GetAxis("Camera Y") * sensitivityCamera;	
		rotationY += Input.GetAxis("Camera X") * sensitivityCamera;

		rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);
		rotationY = Mathf.Clamp (rotationY, -sides - offset, sides);

		Vector3 localRot = new Vector3 (rotationX, rotationY, 0);
		this.transform.localEulerAngles = localRot;

		Vector3 locAngle = new Vector3(rotationY, -rotationX, 90);
		this.transform.localPosition = (new Vector3(-locAngle.x/6,-locAngle.y/3 + offset,Mathf.Abs(locAngle.x/3)-10) - (Vector3.Normalize (locAngle)* distFromShip));
        
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


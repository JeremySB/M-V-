using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * By: Jeremy Bost
 * 
 * Attach to Player object
 * Assumes "Ship" is a child
 */

public class PlayerControl : MonoBehaviour {

    public float thrusterPower = 1.5f;
    public float maxSpeed = 200.0f;
    public float brakeMultiplier = .95f;
    private Vector3 velocity = Vector3.zero;

    CharacterController characterController;
    Transform ship;
	//CameraControl cam;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        ship = transform.Find("Ship");
    }
	
	// Update is called once per frame
	void Update () {
        


        float thrust = Input.GetAxis("Thrust") * thrusterPower;

        velocity += thrust * ship.forward;


        
        if (Input.GetAxis("Brake")!=0)//Input.GetKey("x"))
            velocity *= brakeMultiplier;

		float side = Input.GetAxis ("Side Thrust") * thrusterPower;

		velocity += side * ship.right;

		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 movement = velocity * Time.deltaTime;
        characterController.Move(movement);

		//if (Input.GetAxis ("Reset Camera")!=0)
			// cam.ResetCamera();
	}
}

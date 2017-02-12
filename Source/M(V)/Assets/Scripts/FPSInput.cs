using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * By: Jeremy Bost
 * 
 * Attach to Player object
 * Assumes "Ship" is a child
 */

public class FPSInput : MonoBehaviour {

    public float speed = 25.0f;
    public float sensitivityRoll = 3.0f;

    CharacterController characterController;
    Transform ship;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        ship = transform.Find("Ship");

        // roll
        float deltaZ = Input.GetAxis("Roll") * sensitivityRoll;

        transform.Rotate(0, 0, deltaZ);

        float thrust = Input.GetAxis("Thrust") * speed;

        Vector3 movement = thrust * ship.forward;

        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        characterController.Move(movement);
	}
}

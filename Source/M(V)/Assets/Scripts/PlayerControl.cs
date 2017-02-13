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

    public float speed = 40.0f;
    

    CharacterController characterController;
    Transform ship;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        ship = transform.Find("Ship");
    }
	
	// Update is called once per frame
	void Update () {
        


        float thrust = Input.GetAxis("Thrust") * speed;

        Vector3 movement = thrust * ship.forward;

        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        characterController.Move(movement);
	}
}

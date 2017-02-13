﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * By: Jeremy Bost
 * 
 * Attach to Player object
 * Assumes "Ship" is a child
 */

public class PlayerControl : MonoBehaviour {

    public float thrusterPower = 10.0f;
    public float maxSpeed = 200.0f;
    private Vector3 velocity = Vector3.zero;

    CharacterController characterController;
    Transform ship;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        ship = transform.Find("Ship");
    }
	
	// Update is called once per frame
	void Update () {
        


        float thrust = Input.GetAxis("Thrust") * thrusterPower;

        velocity += thrust * ship.forward;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 movement = velocity * Time.deltaTime;
        characterController.Move(movement);
	}
}

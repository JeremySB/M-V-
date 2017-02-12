using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {

    public float speed = 25.0f;
    
    CharacterController characterController;
    Transform ship;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        ship = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
        
        float thrust = Input.GetAxis("Thrust") * speed;

        Vector3 movement = thrust * ship.forward;

        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
	}
}

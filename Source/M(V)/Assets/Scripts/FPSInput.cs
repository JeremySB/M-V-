using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {

    public float speed = 25.0f;
    public float sensitivityPitch = 5.0f;
    public float sensitivityYaw = 5.0f;
    public float sensitivityRoll = 5.0f;

    CharacterController characterController;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // ship rotations

        // pitch
        float deltaX = -Input.GetAxis("Vertical") * sensitivityPitch;

        // yaw
        float deltaY = Input.GetAxis("Horizontal") * sensitivityYaw;

        // roll
        float deltaZ = Input.GetAxis("Roll") * sensitivityRoll;

        transform.Rotate(deltaX, deltaY, deltaZ);

        float thrust = Input.GetAxis("Thrust") * speed;

        Vector3 movement = new Vector3(0, 0, thrust);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour {

    public float sensitivityPitch = 5.0f;
    public float sensitivityYaw = 5.0f;
    public float sensitivityRoll = 3.0f;

    CharacterController characterController;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        // pitch
        float deltaX = -Input.GetAxis("Vertical") * sensitivityPitch;

        // yaw
        float deltaY = Input.GetAxis("Horizontal") * sensitivityYaw;

        // roll
        float deltaZ = Input.GetAxis("Roll") * sensitivityRoll;

        transform.Rotate(deltaX, deltaY, deltaZ);
	}
}

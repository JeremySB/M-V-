using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * By: Jeremy Bost
 * 
 * Attach to Ship object
 */

public class ShipControl : MonoBehaviour {

    public float sensitivityPitch = 4.0f;
    public float sensitivityYaw = 4.0f;
    public float sensitivityRoll = 3.0f;

    public float thrusterPower = 80000f;
    public float sideThrusterPower = 40000f;
    public float brakeMultiplier = .95f;

    public float turnSpeed = 0.1f;

    Rigidbody rb;

    public Transform mainCamera;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update() {

        /*
        * Rotations
        */
        

        // move towards camera view
        Quaternion target = Quaternion.Slerp(transform.rotation, mainCamera.rotation, turnSpeed);

        Quaternion savedRotation = mainCamera.rotation;
        transform.rotation = target;
        mainCamera.rotation = savedRotation;

    }

    // FixedUpdate is better for forces/RB stuff
    void FixedUpdate() { 

        /*
         * Thrust/forces
         */

        float forwardThrust = Input.GetAxis("Thrust") * thrusterPower;
        rb.AddForce(forwardThrust * transform.forward);

        float sideThrust = Input.GetAxis("Side Thrust") * sideThrusterPower;
        rb.AddForce(sideThrust * transform.right);

        float vertThrust = Input.GetAxis("Vertical Thrust") * sideThrusterPower;
        rb.AddForce(vertThrust * transform.up);

        // roll
        float deltaZ = Input.GetAxis("Roll") * sensitivityRoll;
        rb.AddTorque(transform.forward * deltaZ * sideThrusterPower);

        if (Input.GetAxis("Brake") != 0)
            rb.velocity *= brakeMultiplier;

        
    }
}

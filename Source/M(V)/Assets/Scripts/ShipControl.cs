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

    public float thrusterPower = 50000f;
    public float sideThrusterPower = 30000f;
    public float brakeMultiplier = .95f;

    Rigidbody rb;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update() {

        /*
         * Rotations
         */

        // pitch
        float deltaX = Input.GetAxis("Pitch") * sensitivityPitch;

        // yaw
        float deltaY = Input.GetAxis("Yaw") * sensitivityYaw;

        // roll
        float deltaZ = Input.GetAxis("Roll") * sensitivityRoll;

        transform.Rotate(deltaX, deltaY, deltaZ);

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

        if (Input.GetAxis("Brake") != 0)
            rb.velocity *= brakeMultiplier;

        
    }
}

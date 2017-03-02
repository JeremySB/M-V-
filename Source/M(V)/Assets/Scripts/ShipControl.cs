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
    public float maxSpeed = 100f;

    public float turnSpeed = 0.1f;

    Rigidbody rb;

    public Transform mainCamera;

    private MenuManager menu;
	private AudioSource[] sources;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        menu = FindObjectOfType<MenuManager>();
		sources = GetComponents<AudioSource> ();
	}

    // Update is called once per frame
    void Update() {

        if (menu.IsMenuShown)
        {
            sources[3].Pause();
            return;
        };

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

        if (menu.IsMenuShown)
        {
            return;
        }

        /*
         * Thrust/forces
         */

        float forwardThrust = Input.GetAxis("Thrust") * thrusterPower;
        
        float sideThrust = Input.GetAxis("Side Thrust") * sideThrusterPower;
        
        float vertThrust = Input.GetAxis("Vertical Thrust") * sideThrusterPower;

        // roll
        float deltaZ = Input.GetAxis("Roll") * sensitivityRoll;

		if ((forwardThrust > 0 || sideThrust != 0 || vertThrust != 0 || deltaZ != 0)) {
			if(!sources[3].isPlaying)
			sources [3].Play ();
		}
		else if (sources [3].isPlaying)
			sources [3].Pause ();

        rb.AddForce(forwardThrust * transform.forward);
        rb.AddForce(sideThrust * transform.right);
        rb.AddForce(vertThrust * transform.up);
        rb.AddTorque(transform.forward * deltaZ * sideThrusterPower);

        if (Input.GetAxis("Brake") != 0)
            rb.velocity *= brakeMultiplier;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        if (rb.velocity.magnitude < 0.1f) rb.velocity = Vector3.zero;
    }
	void OnCollisionEnter(Collision col){
        int toPlay = Random.Range(0, 3);
		if(!sources[toPlay].isPlaying)
			sources [toPlay].Play ();
	}
}

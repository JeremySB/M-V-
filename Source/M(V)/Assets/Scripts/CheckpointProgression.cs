using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointProgression : MonoBehaviour {
    public Transform nextCheckpoint;

	// Use this for initialization
	void Start () {
        if (!CompareTag("Start"))
        {
            GetComponent<Renderer>().enabled = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().enabled = false;
            nextCheckpoint.GetComponent<Renderer>().enabled = true;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}

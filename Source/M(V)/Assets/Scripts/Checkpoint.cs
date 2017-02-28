using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	Checkpoints parent;
	// Use this for initialization
	void Start () {
		parent = this.transform.parent.GetComponent<Checkpoints>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GetComponent<Renderer>().enabled)
        {
            GetComponent<AudioSource>().Play();
			parent.Next();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}

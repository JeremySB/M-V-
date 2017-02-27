using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
	public Checkpoint[] checkpoints;
	public Checkpoint currentCheckpoint;
	private int currentCheckpointIndex = 0;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < checkpoints.Length; i++)
			checkpoints [i].GetComponent<Renderer> ().enabled = false;
		
		currentCheckpoint = checkpoints [currentCheckpointIndex];
		currentCheckpoint.GetComponent<Renderer> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void next(){
		currentCheckpoint.GetComponent<Renderer> ().enabled = false;
		if(currentCheckpointIndex < checkpoints.Length){
			currentCheckpoint = checkpoints [++currentCheckpointIndex];
			currentCheckpoint.GetComponent<Renderer> ().enabled = true;
		}
	}
}

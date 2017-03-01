using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
	public Checkpoint[] checkpoints;
	private Checkpoint currentCheckpoint;
    public Transform ship;
    public Transform spawnPoint;
    public Transform cam;
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

	public void Next(){
		currentCheckpoint.GetComponent<Renderer> ().enabled = false;
		if(currentCheckpointIndex < checkpoints.Length - 1){
			currentCheckpoint = checkpoints [++currentCheckpointIndex];
			currentCheckpoint.GetComponent<Renderer> ().enabled = true;
		}
        else if(currentCheckpointIndex == checkpoints.Length - 1)
        {
            currentCheckpointIndex = 0;
            currentCheckpoint = checkpoints[++currentCheckpointIndex];
            currentCheckpoint.GetComponent<Renderer>().enabled = true;
            ResetShip();
        }
	}

    // reset ship to spawnpoint
    private void ResetShip()
    {
        ship.position = spawnPoint.position;
        ship.rotation = spawnPoint.rotation;
        cam.rotation = spawnPoint.rotation;
        ship.GetComponent<Rigidbody>().velocity = Vector3.zero;
        FindObjectOfType<HUDControl>().timer = -1;
    }
}

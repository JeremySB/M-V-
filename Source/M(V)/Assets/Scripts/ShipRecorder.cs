using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum keyValue {Thrust=0,Stop=1,PosPitch=2,NegPitch=4,PosRoll=8,NegRoll=16,PosYaw=24,NegYaw=48};
enum keyState {Pressed,Released};

struct InputData{
	keyValue key;
	keyState state;
	float timestamp;
};

public class ShipRecorder : MonoBehaviour {
	private float runtime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAsteroids : MonoBehaviour {
    public float spd;


	// Use this for initialization
	void Start () {
        spd = 0.6f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,spd,Space.Self);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour {
    private int spinSpeed;
	// Use this for initialization
	void Start () {
        spinSpeed = 20;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(spinSpeed * Time.deltaTime, 0, 0);
    }
}

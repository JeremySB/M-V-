using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolvingAsteroids : MonoBehaviour {
    public GameObject centerPoint;
    public float spd;
    private Vector3 position;

	// Use this for initialization
	void Start () {
        spd = 0.5f;
        position = centerPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(0,0,spd,Space.)
	}
}

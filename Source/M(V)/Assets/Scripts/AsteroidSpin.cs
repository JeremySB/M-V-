using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpin : MonoBehaviour {
    public float spd;
    public Vector3 rotation;

	// Use this for initialization
	void Start () {
        spd = 0.05f;
        rotation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rotation *= spd;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation);
	}
}

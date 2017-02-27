using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpin : MonoBehaviour {
    public float spd;
    public Vector3 rotation;
	// Use this for initialization
	void Start () {
        //spd = Random.Range(0.02f, 0.3f);
        spd = 1 - (transform.localScale.magnitude / 50000f);
        rotation = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        rotation.x *= spd;
        rotation.y *= spd;
        rotation.z *= spd;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation);
	}
}

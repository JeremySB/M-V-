using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterParticlesControl : MonoBehaviour {

    private ParticleSystem particles;
    public string AttachedAxis;

	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis(AttachedAxis) > 0.01)
        {
            particles.Play();
        }
        else
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        
	}
}

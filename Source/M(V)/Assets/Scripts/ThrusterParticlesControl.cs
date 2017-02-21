using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterParticlesControl : MonoBehaviour {

    private ParticleSystem particles;
    public string PosAxis1, PosAxis2, NegAxis1, NegAxis2;

    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis(PosAxis1) > 0.01f || Input.GetAxis(PosAxis2) > 0.01f)
        {
            particles.Play();
        }
        else if (Input.GetAxis(NegAxis1) < -0.01f || Input.GetAxis(NegAxis2) < -0.01f)
        {
            particles.Play();
        }
        else
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        
	}
}

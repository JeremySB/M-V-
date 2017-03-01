using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	Checkpoints parent;
    public bool fading;
    private Color originalColor;
    private float fadePerSecond = 2.5f;
    // Use this for initialization
    void Start () {
		parent = this.transform.parent.GetComponent<Checkpoints>();
        fading = false;
        originalColor = this.GetComponent<MeshRenderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GetComponent<Renderer>().enabled)
        {
            GetComponent<AudioSource>().Play();
			parent.Next();
        }
    }
    // Update is called once per frame
    void Update () {
        if (fading)
        {
            Material material = GetComponent<MeshRenderer>().material;
            Color color = material.color;

            material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
        }
        if(this.GetComponent<MeshRenderer>().material.color.a <= 0)
        {
            this.GetComponent<Renderer>().enabled = false;
            GetComponent<MeshRenderer>().material.color = originalColor;
            fading = false;
        }
    }
}

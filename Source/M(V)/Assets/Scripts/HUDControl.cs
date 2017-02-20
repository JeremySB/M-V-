using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControl : MonoBehaviour {

    public Rigidbody ship;
    public Camera cam;
    public RectTransform dot;
    public RectTransform circle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        circle.anchoredPosition3D = cam.WorldToScreenPoint(ship.transform.forward + cam.transform.position);
        dot.anchoredPosition3D = cam.WorldToScreenPoint(ship.velocity + cam.transform.position) + new Vector3(0, 0, 0);

        if(ship.velocity.magnitude > 5 && dot.anchoredPosition3D.z >= 0)
        {
            dot.gameObject.SetActive(true);
        }
        else
        {
            dot.gameObject.SetActive(false);
        }
        
	}
}

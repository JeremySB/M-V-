using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour {

    public Rigidbody ship;
    public Camera cam;
    public RectTransform dot;
    public RectTransform circle;
    public Text timerText; 

    private float timer = -1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timer >= 0)
        {
            timer += Time.deltaTime;
        }
        else if(ship.velocity.magnitude > 1)
        {
            timer = 0;
        }

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

    private void OnGUI()
    {
        if (timer >= 0)
        {
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            timerText.text = "Time Elapsed:\n" + niceTime;
        }
        else
        {
            timerText.text = "Start moving to begin!";
        }
    }
}

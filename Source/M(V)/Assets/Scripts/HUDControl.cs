using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour {

    public Rigidbody ship;
    public Camera cam;
    public Checkpoints checkpoints;
    public RectTransform dot;
    public RectTransform circle;
    public RectTransform arrow;
    public Text timerText; 
	public Text speedText;

    private float timer = -1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //checkpoint indicator
        Vector3 screenpos = cam.WorldToScreenPoint(checkpoints.currentCheckpoint.transform.position);
        if (screenpos.z > 0 && screenpos.x > 0 && screenpos.x < Screen.width &&
            screenpos.y > 0 && screenpos.y < Screen.height)
        {
            arrow.gameObject.SetActive(false);
        }
        else {
            arrow.gameObject.SetActive(true);
            float x = screenpos.x;
            float y = screenpos.y;
            float offset = 40;

            if (screenpos.z < 0)
            {
                screenpos = -screenpos;
            }

            if (screenpos.x > Screen.width)
            {
                x = Screen.width - offset;
            }
            if (screenpos.x < 0)
            {
                x = offset;
            }

            if (screenpos.y > Screen.height)
            {
                y = Screen.height - offset;
            }
            if (screenpos.y < 0)
            {
                y = offset;
            }
            arrow.transform.position = new Vector3(x, y, 0);
            float angle = Mathf.Atan2(screenpos.y, screenpos.x);
            angle -= 90 * Mathf.Deg2Rad;
            arrow.transform.localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
        }
        //end offscreen indicator
        if (timer >= 0)
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

        //speedText.text = ship.velocity.magnitude.ToString() + " Kph";
        speedText.text = "";
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

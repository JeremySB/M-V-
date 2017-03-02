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

    public float timer { get; set; }

    // Use this for initialization
    void Start () {
        timer = -1;
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
            //float angle = Mathf.Atan2(y, x);
            //float angle = Mathf.Atan2(screenpos.y-(Screen.height/2), screenpos.x - (Screen.width/2));
            if (screenpos.z < 0)
            {
                screenpos = -screenpos;
                y = offset;
            }
            float angle = Mathf.Atan2(screenpos.y - (Screen.height / 2), screenpos.x - (Screen.width / 2));
            if (screenpos.x > Screen.width)
            {
                x = Screen.width - offset;
            }
            if (screenpos.x < 0)
            {
                x = offset;
                //angle += 90 * Mathf.Deg2Rad;
                //arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            if (screenpos.y > Screen.height)
            {
                y = Screen.height - offset;
                //arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (screenpos.y < 0)
            {
                y = offset;
                //angle -= 90 * Mathf.Deg2Rad;
                //arrow.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            arrow.transform.position = new Vector3(Mathf.Abs(x), Mathf.Abs(y), 0);
            //if (arrow.transform.position.y == 40 || arrow.transform.position.x == 40)
            //{
            //    angle += 90 * Mathf.Deg2Rad;
            //}
            //angle = Mathf.Atan2(y, x);
            arrow.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
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

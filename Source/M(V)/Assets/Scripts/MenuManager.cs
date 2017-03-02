using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject StartPanel;
    public GameObject PausePanel;
    public Text recordTimeText;

    private bool menuShown;
    private GameObject hud;
    private static string recordTimeKey = "Record Time";
    private float recordTime;
    
    void Awake()
    {
        menuShown = true;
        recordTime = -1f;
    }

    // Use this for initialization
    void Start () {
        recordTime = PlayerPrefs.GetFloat(recordTimeKey, recordTime);
        UpdateRecordTimeDisplay();
        hud = FindObjectOfType<HUDControl>().gameObject;
        ShowMenu();
	}
	
	// Update is called once per frame
	void Update () {
		if(!menuShown)
        {
            if(Input.GetButtonDown("Cancel"))
            {
                PausePanel.SetActive(true);
                ShowMenu();
            }
        }
        else if(PausePanel.activeInHierarchy)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                PausePanel.SetActive(false);
                HideMenu();
            }
        }
	}

    private void HideMenu()
    {
        menuShown = false;
        hud.SetActive(true);
        Time.timeScale = 1.0f;
        Input.ResetInputAxes();
    }

    private void ShowMenu()
    {
        Input.ResetInputAxes();
        menuShown = true;
        hud.SetActive(false);
        Time.timeScale = 0.0f;
    }

    private void UpdateRecordTimeDisplay(bool gameOverScreen = false, bool beatLastTime = false, float playerTime = -1f)
    {
        if (recordTime < 0)
        {
            recordTimeText.text = "Play to set the first record time!";
        }
        else
        {
            string message;
            if (gameOverScreen && beatLastTime)
            {
                message = "Congratulations, you set the record time!\nNew record time: ";
            }
            else if (gameOverScreen && !beatLastTime && playerTime > 0)
            {
                int minutesOld = Mathf.FloorToInt(playerTime / 60F);
                int secondsOld = Mathf.FloorToInt(playerTime - minutesOld * 60);
                message = "Your time: " + string.Format("{0:0}:{1:00}", minutesOld, secondsOld) + "\nRecord time: ";
            }
            else
            {
                message = "Record time: ";
            }

            int minutes = Mathf.FloorToInt(recordTime / 60F);
            int seconds = Mathf.FloorToInt(recordTime - minutes * 60);
            recordTimeText.text = message + string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    public void GameOver()
    {
        float time = hud.GetComponent<HUDControl>().timer;
        if(recordTime < 0 || recordTime > time)
        {
            // beat record time
            recordTime = time;
            PlayerPrefs.SetFloat(recordTimeKey, recordTime);
            UpdateRecordTimeDisplay(true, true);
        }
        else
        {
            UpdateRecordTimeDisplay(true, false, time);
        }

        StartPanel.SetActive(true);
        ShowMenu();
        hud.GetComponent<HUDControl>().timer = -1;
    }

    public void RestartGame()
    {
        hud.GetComponent<HUDControl>().timer = -1;
        FindObjectOfType<Checkpoints>().ResetShip();
        PausePanel.SetActive(false);
        HideMenu();
    }

    public void StartGame()
    {
        StartPanel.SetActive(false);
        HideMenu();
    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        HideMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting not supported in editor");
    }

    public void ClearTime()
    {
        PlayerPrefs.DeleteKey(recordTimeKey);
        recordTime = -1;
        UpdateRecordTimeDisplay();
    }

    public bool IsMenuShown
    {
        get { return menuShown; }
    }
}

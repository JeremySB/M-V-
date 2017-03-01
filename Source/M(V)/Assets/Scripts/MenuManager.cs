using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject StartPanel;
    public GameObject PausePanel;

    private bool menuShown = true;
    private GameObject hud;
    
    void Awake()
    {
        menuShown = true;
    }

    // Use this for initialization
    void Start () {
        hud = FindObjectOfType<HUDControl>().gameObject;
        ShowMenu();
	}
	
	// Update is called once per frame
	void Update () {
		if(!menuShown)
        {
            if(Input.GetButtonDown("Pause"))
            {
                PausePanel.SetActive(true);
                ShowMenu();
            }
        }
        else if(PausePanel.activeInHierarchy)
        {
            if (Input.GetButtonDown("Pause"))
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
    }

    private void ShowMenu()
    {
        menuShown = true;
        hud.SetActive(false);
        Time.timeScale = 0.0f;
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

    public bool IsMenuShown
    {
        get { return menuShown; }
    }
}

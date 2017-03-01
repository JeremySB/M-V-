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
        Time.timeScale = 0.0f;
        hud = FindObjectOfType<HUDControl>().gameObject;
        hud.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!menuShown)
        {
            if(Input.GetButtonDown("esc"))
            {

            }
        }
	}

    private void HideMenu()
    {
        menuShown = false;
        hud.SetActive(true);
        Time.timeScale = 1.0f;
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
    }

    public bool IsMenuShown
    {
        get { return menuShown; }
    }
}

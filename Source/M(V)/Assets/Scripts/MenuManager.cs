using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject StartPanel;

    private bool menuShown;

    public bool IsMenuShown
    {
        get { return menuShown; }
    }

    void Awake()
    {
        menuShown = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        StartPanel.SetActive(false);
        menuShown = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

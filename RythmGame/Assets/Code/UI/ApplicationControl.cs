using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationControl : MonoBehaviour {

    public static ApplicationControl Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is already an instance of an ApplicationControl");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool IsFirstTimeUse()
    {
        //Return true if the app is being used for the first time
        if (PlayerPrefs.GetInt("HasPlayed") == 0)
        {
            //We don't set being used here because the player can still return from the screen to main before playing
            return true;
        }
        //Return false if the app has been used before
        else
        {
            return false;
        }
    }
}

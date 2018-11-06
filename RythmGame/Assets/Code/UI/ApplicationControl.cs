using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationControl : MonoBehaviour {

    public static ApplicationControl Instance;

    private bool m_InitializedFacebook = false;

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
        return false;
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

    ////We have a extra function layer to add behaviour
    //public void LogInToFacebook()
    //{
    //    LogInFacebook();
    //}

    //public void LogOutOfFacebook()
    //{
    //    LogOutFacebook();
    //}

    //private void InitializeFacebook()
    //{
    //    if (m_InitializedFacebook == false)
    //    {
    //        FB.Init(this.OnInitFinish, this.OnLoseApplicationFocus);
    //        m_InitializedFacebook = true;
    //    }
    //}

    //private void LogInFacebook()
    //{
    //    FB.LogInWithReadPermissions(new List<string>() { "public_profile" }, this.HandleResults);
    //}

    //private void LogOutFacebook()
    //{
    //    FB.LogOut();
    //}

    //private void OnInitFinish()
    //{
    //    //Add logic to run when Facebook initialization finished
    //}

    //private void OnLoseApplicationFocus(bool IsGameShown)
    //{
    //    //Add logic here to run when facebook displays own content in front of our application by excample
    //    //the login screen.
    //}

    //private void HandleResults(IResult Result)
    //{
    //    //Add Logic to handle responses example: What to do when login fails?

    //    //The event succeeded
    //    if (!string.IsNullOrEmpty(Result.RawResult))
    //    {
    //        Debug.Log("Login Succes");
    //    }
    //}


}

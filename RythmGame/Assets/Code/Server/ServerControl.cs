using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ServerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UploadScore(string Username, int Score, int Level)
    {
        //TODO implement upload function

        StartCoroutine(Upload(Username, Score, Level));
    }

    private IEnumerator Upload(string Username, int Score, int Level)
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", Username);
        form.AddField("Score", Score);
        form.AddField("Level", Level);

        WWW www = new WWW("http://slicebeatkitchen.000webhostapp.com/", form);
        yield return www;
    }
}

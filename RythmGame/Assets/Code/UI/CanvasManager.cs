using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    public static CanvasManager Instance;

    [SerializeField]
    private List<Canvas> m_Canvases = new List<Canvas>();
    private int m_CurrentIndex = 0;
    private int m_PreviousIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is already an instance of a CanvasManager");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Switches to new canvas and disables the old one
    public void SwitchToCanvas(int ID)
    {
        if (ID != m_CurrentIndex)
        {
            m_PreviousIndex = m_CurrentIndex;
            m_Canvases[m_PreviousIndex].gameObject.SetActive(false);
        }

        if (ID < m_Canvases.Count)
        {
            m_Canvases[ID].gameObject.SetActive(true);
            m_CurrentIndex = ID;
        }
    }

    public void GoBackToPrevious()
    {
        SwitchToCanvas(m_PreviousIndex);
    }

    //Use different function because we want to check use first
    public void GoToLevelSelect()
    {
        //If first time using app ask if want to use Facebook
        if (ApplicationControl.Instance.IsFirstTimeUse())
        {
            SwitchToCanvas(2);
        }
        //Load level select app has been used before
        else
        {

        }
    }

    public void GoToFacebook()
    {
        ApplicationControl.Instance.LogInToFacebook();
    }

    public void GetOffFacebook()
    {
        ApplicationControl.Instance.LogOutOfFacebook();
    }
}

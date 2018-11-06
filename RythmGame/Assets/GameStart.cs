using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private Animator anim;
    private bool started;


    [SerializeField] private GameObject otherCanvas;
    [SerializeField] private AudioSource sliceFX;

    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (started)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            started = true;
            anim.SetTrigger("start");
        }	
	}

    public void SliceFX()
    {
        sliceFX.Play();
    }

    public void SwitchMenus()
    {
        otherCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}

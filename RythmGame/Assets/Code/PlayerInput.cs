using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public List<double> clickTimes = new List<double>();
    int currentClick;

    [SerializeField] private double perfectScoreDif;
    [SerializeField] private double OkayScoreDif;

    private void Update()
    {
        CheckMissed();

        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }
    }

    public void CheckMissed()
    {
        if((clickTimes[currentClick] + perfectScoreDif) <= Time.timeSinceLevelLoad)
        {
            currentClick++;
            print("Missed");
        }
    }

    public void CheckClick()
    {
        if(clickTimes[currentClick] - perfectScoreDif <= Time.timeSinceLevelLoad)
        {
            print("Perfect");
            currentClick++;
        }
        else if(clickTimes[currentClick] - OkayScoreDif <= Time.timeSinceLevelLoad)
        {
            print("Okay");
            currentClick++;
        }
        else if (clickTimes[currentClick] - 0.5f >= Time.timeSinceLevelLoad)
        {
            print("ignore");
        }
        else
        {
            print("Bad");
            currentClick++;
        }
    }
}

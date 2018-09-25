using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public List<double> clickTimes = new List<double>();
    private int currentClick;

    [SerializeField] private ScoreManager score;
    [SerializeField] private MapReader reader;

    [SerializeField] private double perfectScoreDif;
    [SerializeField] private double OkayScoreDif;
    private float missAfterTime = 0.1f;

    [SerializeField] private AudioSource audio;

    private void Start()
    {
        perfectScoreDif = perfectScoreDif / reader.mapSpeed;
        OkayScoreDif = OkayScoreDif / reader.mapSpeed;
        missAfterTime = missAfterTime / reader.mapSpeed;
    }

    private void Update()
    {
        if (clickTimes.Count == currentClick)
            return;

        CheckMissed();

        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
            audio.Play();
        }
    }

    public void CheckMissed()
    {
        if((clickTimes[currentClick] / reader.mapSpeed) + missAfterTime <= Time.timeSinceLevelLoad)
        {
            currentClick++;
            score.ScorePoints(0, "Miss");
        }
    }

    public void CheckClick()
    {
        if ((clickTimes[currentClick] / reader.mapSpeed) - perfectScoreDif <= Time.timeSinceLevelLoad)
        {
            score.ScorePoints(500, "Perfect");
            SliceIndicatorCuts.Instance.Cut();
            currentClick++;
        }
        else if ((clickTimes[currentClick] / reader.mapSpeed) - OkayScoreDif <= Time.timeSinceLevelLoad)
        {
            score.ScorePoints(250, "Okay");
            SliceIndicatorCuts.Instance.Cut();
            currentClick++;
        }
        else if ((clickTimes[currentClick] / reader.mapSpeed ) - 0.5f >= Time.timeSinceLevelLoad)
        {
            return;
        }
        else
        {
            score.ScorePoints(100, "Bad");
            SliceIndicatorCuts.Instance.Cut();
            currentClick++;
        }
    }
}

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

    public bool started;
    public float timeSinceStart;

    private void Start()
    {
        missAfterTime = missAfterTime / reader.mapSpeed;
    }

    private void Update()
    {
        if (!started)
            return;
        
        timeSinceStart += Time.deltaTime;

        if (timeSinceStart >= 65f)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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
        if ((clickTimes[currentClick]) + missAfterTime <= timeSinceStart)
        {
            currentClick++;
            score.ScorePoints(0, "Miss");
        }
    }

    public void CheckClick()
    {
        if ((clickTimes[currentClick]) - perfectScoreDif <= timeSinceStart)
        {
            score.ScorePoints(500, "Perfect");
            SliceIndicatorCuts.Instance.Cut();
            currentClick++;
        }
        else if ((clickTimes[currentClick]) - OkayScoreDif <= timeSinceStart)
        {
            score.ScorePoints(250, "Okay");
            SliceIndicatorCuts.Instance.Cut();
            currentClick++;
        }
        else if ((clickTimes[currentClick]) - 0.5f >= timeSinceStart)
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

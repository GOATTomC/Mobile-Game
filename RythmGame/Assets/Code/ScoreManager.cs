using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
 {
    private float totalScore;

    [SerializeField] private string baseScoreText;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject newScorePrefab;

    private int ComboCounter;

    [SerializeField] private int startComboBoost1;
    [SerializeField] private int startComboBoost2;
    [SerializeField] private int startComboBoost3;

    private float comboBoost1 = 1.5f;
    private float comboBoost2 = 2f;
    private float comboBoost3 = 2.5f;

    private float currentBoost;


    void Start ()
    {
        totalScoreText.text = baseScoreText + " " + totalScore.ToString();
	}

    public void ScorePoints(int value, string text)
    {
        if(text == "Okay" || text == "Perfect")
        {
            ComboCounter++;
            if (ComboCounter > startComboBoost1)
                currentBoost = comboBoost1;
            if (ComboCounter > startComboBoost2)
                currentBoost = comboBoost2;
            if (ComboCounter > startComboBoost3)
                currentBoost = comboBoost3;
        }
        else
        {
            ComboCounter = 0;
            currentBoost = 1f;
        }

        Text t = Instantiate(newScorePrefab, Vector3.up, Quaternion.identity).GetComponent<Text>();
        t.transform.SetParent(canvas.transform,false);
        t.rectTransform.anchoredPosition = new Vector2(0 , 380);
        t.rectTransform.position += new Vector3(0, 200,0);
        string scoreText = text + " +" + value.ToString();
        if (currentBoost != 1)
            scoreText += " X" + currentBoost.ToString();
        t.text = scoreText;

        totalScore += value * currentBoost;
        totalScoreText.text = baseScoreText + " " + totalScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
 {
    public float totalScore;

    [SerializeField] private string baseScoreText;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject newScorePrefab;

    [SerializeField] List<Sprite> scoreSprites = new List<Sprite>();
    Sprite spriteToSpawn;

    private int ComboCounter;

    [SerializeField] private int startComboBoost1;
    [SerializeField] private int startComboBoost2;
    [SerializeField] private int startComboBoost3;

    private float comboBoost1 = 1.5f;
    private float comboBoost2 = 2f;
    private float comboBoost3 = 2.5f;

    private float currentBoost = 1;
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

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

            if (text == "Perfect")
                spriteToSpawn = scoreSprites[0];
            else
                spriteToSpawn = scoreSprites[1];
        }
        else
        {
            ComboCounter = 0;
            currentBoost = 1f;
            if (text == "Bad")
                spriteToSpawn = scoreSprites[2];
            else
                spriteToSpawn = scoreSprites[3];
        }

        SpriteRenderer renderer = Instantiate(newScorePrefab, Vector3.up, Quaternion.identity).GetComponent<SpriteRenderer>();
        renderer.transform.position = new Vector3(0, 5.55f);
        renderer.sprite = spriteToSpawn;

        totalScore += value * currentBoost;
        totalScoreText.text = baseScoreText + " " + totalScore.ToString();
    }
}

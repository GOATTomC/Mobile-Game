using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager {

    private int m_CurrentScore = 0;

    public int CurrentScore { get { return m_CurrentScore; } }

    //<summary>
    // Adds an amount of score to the current score
    //</summary>
    public void AddScore(int AmountToAdd)
    {
        if (AmountToAdd < 0)
        {
            Debug.LogError("Score you want to add can't be under 0");
            return;
        }

        m_CurrentScore += AmountToAdd;
    }

    //<summary>
    // Substracts an amount of score from the current score
    //</summary>
    public void SubstractScore(int AmountToSubstract)
    {
        if (AmountToSubstract < 0)
        {
            Debug.LogError("Score you want to substract can't be under 0");
            return;
        }

        m_CurrentScore -= AmountToSubstract;
    }
}

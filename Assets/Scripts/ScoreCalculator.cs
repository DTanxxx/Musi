using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    private int totalScore = 0;
    private int maxCombo = 0;
    private int currentRun = 0;

    public int CalculateCurrentScore(int scoreToAdd)
    {
        totalScore += scoreToAdd;
        return totalScore;
    }

    public int CalculateCurrentCombo(int scoreToAdd)
    {
        if (scoreToAdd == 0)
        {
            maxCombo = Mathf.Max(maxCombo, currentRun);
            currentRun = 0;
        }
        else
        {
            currentRun += 1;
        }
        return currentRun;
    }

    public int GetMaxCombo()
    {
        return Mathf.Max(maxCombo, currentRun);
    }
}

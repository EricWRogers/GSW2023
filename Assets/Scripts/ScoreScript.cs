using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int scoreAmountOnEnd;
    public int currentScore;

    public TMP_Text scoreText;

    void Start()
    {
        InitVariables();
    }

    // Starting score for each player.
    public void InitVariables()
    {
        currentScore = 0;
    }

    // A point is added to a player's score.
    public void AddToScore()
    {
        currentScore += 1;
        currentScore = scoreAmountOnEnd;
        scoreText.text = scoreAmountOnEnd.ToString("Score:" + scoreAmountOnEnd);
    }

}

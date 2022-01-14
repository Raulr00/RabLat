using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]public TextMeshProUGUI scoreTxt;
    [SerializeField]public TextMeshProUGUI highScoreTxt;
    private void Awake()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", -1);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }

        PlayerPrefs.Save();
        scoreTxt.text = score.ToString();
        highScoreTxt.text = highScore.ToString();

    }
}

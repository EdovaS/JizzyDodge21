using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // ? Implement Later in a way that the max score required to go to next level will be changed by seeing the current level.
    
    public TextMeshProUGUI ScoreTextTMP;
    [SerializeField] private GameData _levelData;
    private int _scoreNumber;

    private void Start()
    {
        _levelData.SetScore(0);
        ScoreTextTMP.text = "100/" + _levelData.GetScore();
    }

    public void IncreaseScore()
    {
        _levelData.AddToScore(1);
        _levelData.AddToHit(1);
        ScoreTextTMP.text = "100/" + _levelData.GetScore();
    }
}
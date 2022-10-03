using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // ? Implement Later in a way that the max score required to go to next level will be changed by seeing the current level.
    
    public TextMeshProUGUI ScoreTextTMP;
    private int _scoreNumber;

    private void Start()
    {
        _scoreNumber = 0;
        ScoreTextTMP.text = "100/" + _scoreNumber;
    }

    public void IncreaseScore()
    {
        _scoreNumber += 1;
        ScoreTextTMP.text = "100/" + _scoreNumber;
    }
}

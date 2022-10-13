using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // ? Implement Later in a way that the max score required to go to next level will be changed by seeing the current level.
    
    public TextMeshProUGUI ScoreTextTMP;
    private GameData _levelData;
    private int _scoreNumber;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) _levelData = GameAssets.i.Level_1_Data;
        if (SceneManager.GetActiveScene().buildIndex == 2) _levelData = GameAssets.i.Level_2_Data;
        if (SceneManager.GetActiveScene().buildIndex == 3) _levelData = GameAssets.i.Level_3_Data;
        if (SceneManager.GetActiveScene().buildIndex == 4) _levelData = GameAssets.i.Level_4_Data;
        if (SceneManager.GetActiveScene().buildIndex == 5) _levelData = GameAssets.i.Level_5_Data;
    }

    private void Start()
    {
        _levelData.SetScore(0);
        if(SceneManager.GetActiveScene().buildIndex == 1)
            ScoreTextTMP.text = _levelData.MaxScore + "/" + _levelData.GetScore();
        if(SceneManager.GetActiveScene().buildIndex == 2)
            ScoreTextTMP.text = _levelData.MaxScore + "/" + _levelData.GetScore();
    }

    public void IncreaseScore()
    {
        _levelData.AddToScore(1);
        _levelData.AddToHit(1);
        PopUpTween();
        ScoreTextTMP.text = _levelData.MaxScore + "/" + _levelData.GetScore();
    }

    void PopUpTween()
    {
         ScoreTextTMP.GetComponent<Transform>().DOShakeScale(0.3f, 0.6f, 8, 0f, true);
    }
}

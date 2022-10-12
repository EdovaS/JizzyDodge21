using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // ? Implement Later in a way that the max score required to go to next level will be changed by seeing the current level.
    
    public TextMeshProUGUI ScoreTextTMP;
    [SerializeField] private GameData _levelData;
    private int _scoreNumber;

    private void Start()
    {
        _levelData.SetScore(0);
        if(SceneManager.GetActiveScene().buildIndex == 1)
            ScoreTextTMP.text = "25/" + _levelData.GetScore();
        if(SceneManager.GetActiveScene().buildIndex == 2)
            ScoreTextTMP.text = "50/" + _levelData.GetScore();
    }

    public void IncreaseScore()
    {
        _levelData.AddToScore(1);
        _levelData.AddToHit(1);
        PopUpTween();
        ScoreTextTMP.text = "100/" + _levelData.GetScore();
    }

    void PopUpTween()
    {
         ScoreTextTMP.GetComponent<Transform>().DOShakeScale(0.3f, 0.6f, 8, 0f, true);
    }
}

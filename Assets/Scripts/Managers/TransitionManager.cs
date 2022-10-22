using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;
    
    void Awake()
    {
        StartSceneTransition();
    }

    public void StartSceneTransition()
    {
        _startingSceneTransition.gameObject.SetActive(true);
    }
    
    public void EndingSceneTransition()
    {
        _endingSceneTransition.gameObject.SetActive(true);
    }

    // Will called From Button in UI
    public void RestartLevel()
    {
        _endingSceneTransition.gameObject.SetActive(true);
        FunctionTimer.Create(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex), 1.1f);

    }
    
    // Will called From Button in UI
    public void NextLevelBtnClicked()
    {
        // ? Trigger The UI Animation of Won;
        EndingSceneTransition();
        FunctionTimer.Create(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1), 1.1f);
    }
    
}

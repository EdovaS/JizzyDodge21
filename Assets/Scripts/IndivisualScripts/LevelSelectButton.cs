using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] private TransitionManager _transitionManager;

    public void LoadScene_1()
    {
        _transitionManager.EndingSceneTransition();
        FunctionTimer.Create(() => SceneManager.LoadScene("Level_1"), 1.1f);
    }
    
    public void LoadScene_2()
    {
        _transitionManager.EndingSceneTransition();
        FunctionTimer.Create(() => SceneManager.LoadScene("Level_2"), 1.1f);
    }
    
    public void LoadScene_3()
    {
        _transitionManager.EndingSceneTransition();
        FunctionTimer.Create(() => SceneManager.LoadScene("Level_3"), 1.1f);
    }
    
    public void LoadScene_4()
    {
        _transitionManager.EndingSceneTransition();
        FunctionTimer.Create(() => SceneManager.LoadScene("Level_4"), 1.1f);
    }
    
    public void LoadScene_5()
    {
        _transitionManager.EndingSceneTransition();
        FunctionTimer.Create(() => SceneManager.LoadScene("Level_5"), 1.1f);
    }
    
}

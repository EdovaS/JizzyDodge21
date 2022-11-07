using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject _endTransition;
    private Action _loadAction;
    
    public void StartGame()
    {
        _endTransition.gameObject.SetActive(true);
        _loadAction = LoadScene1;
        FunctionTimer.Create(_loadAction, 1f);
        
    }

    private void LoadScene1()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}

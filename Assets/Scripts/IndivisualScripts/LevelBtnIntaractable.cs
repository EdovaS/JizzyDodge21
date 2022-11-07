using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBtnIntaractable : MonoBehaviour
{
    [SerializeField] private Button[] _lvlButtons;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1); /* < Change this int value to whatever your
                                                             level selection build index is on your
                                                             build settings */

        for (int i = 0; i < _lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                _lvlButtons[i].interactable = false;
        }
    }
}

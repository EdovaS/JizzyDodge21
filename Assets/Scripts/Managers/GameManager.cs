using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   private GameData _levelData;
   
   [SerializeField] private GameObject _gameOverUI;
   [SerializeField] private GameObject _gameWonUI;
   private float _scoreRef;

   private void Awake()
   {
      if (SceneManager.GetActiveScene().buildIndex == 1) _levelData = GameAssets.i.Level_1_Data;
      if (SceneManager.GetActiveScene().buildIndex == 2) _levelData = GameAssets.i.Level_2_Data;
      if (SceneManager.GetActiveScene().buildIndex == 3) _levelData = GameAssets.i.Level_3_Data;
      if (SceneManager.GetActiveScene().buildIndex == 4) _levelData = GameAssets.i.Level_4_Data;
      if (SceneManager.GetActiveScene().buildIndex == 5) _levelData = GameAssets.i.Level_5_Data;
   }
   
   public void GameOver()
   {
      _gameOverUI.SetActive(true);
   }

   // Called Using Event in Inspector
   public void IncrementScoreReferenceVar()
   {
      _scoreRef += 1;

      if (_scoreRef >= _levelData.MaxScore)
      {
         Won();
      }
   }

   [Button]
   private void Won()
   {
      GameObject.FindGameObjectWithTag("Player").gameObject.SetActive(false);
      SoundManager.PlaySound(SoundManager.Sound.PlayerWon);
      _gameWonUI.gameObject.SetActive(true);
   }

   
}

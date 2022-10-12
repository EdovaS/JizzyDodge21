using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private GameObject _gameOverUI;
   
   
   public void GameOver()
   {
      _gameOverUI.SetActive(true);
   }
}

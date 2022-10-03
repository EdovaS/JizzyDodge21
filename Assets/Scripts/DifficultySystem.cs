using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySystem : MonoBehaviour
{
    [SerializeField] private GameData _gameData;

    private void Start()
    {
        _gameData.SetEnemySpeed(-10);
        _gameData.SetTimeBetweenSpawn(1.5f);
        _gameData.SetHit(0);
    }

    private void Update()
    {
        if (_gameData.GetHit() > _gameData.EveryHit)
        {
            _gameData.AddToEnemySpeed(_gameData.EnemySpeedIncrement); // Add Speed
            
            // As long as TimeBetweenSpawn is greater than 0.3f than, the TimeBetweenSpawn will decrement. Else no;
            if (_gameData.GetTimeBetweenSpawn() > _gameData.MinimumTimeBetweenSpawn)
            {
                _gameData.AddToTimeBetweenSpawn(_gameData.TimeBetweenSpawnDecrement); // Decrement from TimeBetweenSpawn    
            }
            
            // set Hit to Zero
            _gameData.SetHit(0);
        }
    }
}

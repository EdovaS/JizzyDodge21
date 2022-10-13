using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySystem : MonoBehaviour
{
    private GameData _levelData;

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
        _levelData.SetEnemySpeed(-10);
        _levelData.SetTimeBetweenSpawn(1.5f);
        _levelData.SetHit(0);
    }

    private void Update()
    {
        if (_levelData.GetHit() > _levelData.EveryHit)
        {
            IncrementEnemySpeed();
            DecrementTimeBetweenSpawn();

            // set Hit to Zero
            _levelData.SetHit(0);
        }
    }

    private void DecrementTimeBetweenSpawn()
    {
        // As long as TimeBetweenSpawn is greater than 0.3f than, the TimeBetweenSpawn will decrement. Else no;
        if (_levelData.GetTimeBetweenSpawn() > _levelData.MinimumTimeBetweenSpawn)
        {
            _levelData.AddToTimeBetweenSpawn(_levelData.TimeBetweenSpawnDecrement); // Decrement from TimeBetweenSpawn    
        }
    }

    private void IncrementEnemySpeed()
    {
        // As long as MaxEnemySpeed is Greater than EnemySpeed than, the EnemySpeed will increment. Else no;
        if (_levelData.MaxEnemySpeed < _levelData.GetEnemySpeed())
        {
            _levelData.AddToEnemySpeed(_levelData.EnemySpeedIncrement); // Add Speed    
        }
    }
}

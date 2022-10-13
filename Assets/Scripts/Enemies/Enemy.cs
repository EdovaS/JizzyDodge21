using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private GameData _levelData;

    // what is an delegate ? 
    // A delegate is a variable that holds function instead of data.
    public delegate void OnDisableCallback(Enemy instance); // ? This is a delegate
    public OnDisableCallback Disable; // ? This is an instance of the delegate 

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) _levelData = GameAssets.i.Level_1_Data;
        if (SceneManager.GetActiveScene().buildIndex == 2) _levelData = GameAssets.i.Level_2_Data;
        if (SceneManager.GetActiveScene().buildIndex == 3) _levelData = GameAssets.i.Level_3_Data;
        if (SceneManager.GetActiveScene().buildIndex == 4) _levelData = GameAssets.i.Level_4_Data;
        if (SceneManager.GetActiveScene().buildIndex == 5) _levelData = GameAssets.i.Level_5_Data;

    }

    void Update()
    {
        transform.Translate(_levelData.GetEnemySpeed() * Time.deltaTime, 0,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AddToPool"))
        {
            Disable?.Invoke(this);
        }
    }
}

using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _Enemies;
    
    private GameData _levelData;
    
    private float _time;

    private ObjectPool<Enemy> _pool;

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
        _pool = new ObjectPool<Enemy>(CreatePooledObject, OnTakeFromPool,
            OnReturnToPool, OnDestroyObject, false, 20, 20);
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _levelData.GetTimeBetweenSpawn())
        {
            _pool.Get();
            _time = 0;
        }
    }

    // ---------- Object Pooling ------------- //
    
    private Enemy CreatePooledObject()
    {
        // We are using _levelData.MaxNumberOfEnemies enemies because in some levels there are different number of enemies.
        Enemy instance = Instantiate(_Enemies[Random.Range(0, _levelData.MaxNumberOfEnemies)].GetComponent<Enemy>(), transform.position, quaternion.identity);
        instance.Disable += ReturnObjectToPool;
        instance.gameObject.SetActive(false);
        
        return instance;
    }

    private void ReturnObjectToPool(Enemy instance)
    {
        _pool.Release(instance);
    }

    private void OnTakeFromPool(Enemy instance)
    {
        instance.gameObject.SetActive(true);
        SpawnEnemy(instance);
        instance.transform.SetParent(transform, true);
    }

    private void OnReturnToPool(Enemy instance)
    {
        instance.gameObject.SetActive(false);
    }

    private void OnDestroyObject(Enemy instance)
    {
        Destroy(instance);
    }

    private void SpawnEnemy(Enemy instance)
    {
        Vector3 spawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        instance.transform.position = spawnLocation;
    }

    private void OnGUI()
    {
        // GUI.Label(new Rect(10, 10, 200, 30), $"Total Pool Size {_pool.CountAll} ");
        // GUI.Label(new Rect(10, 30, 200, 30), $"Active Objects {_pool.CountActive} ");
    }
}
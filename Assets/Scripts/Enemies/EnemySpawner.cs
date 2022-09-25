using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _Enemies;

    [SerializeField] private float _timeBetweenSpawn;
    private float _time;
    
    private void Update()
    {
        _time += Time.deltaTime;
        
        if (_time > _timeBetweenSpawn)
        {
            Instantiate(_Enemies[Random.Range(0, 1)], transform.position, Quaternion.identity);
            _time = 0;
        }    
    }
}

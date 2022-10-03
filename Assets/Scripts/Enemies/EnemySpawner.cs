using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _Enemies;
    
    [SerializeField] private GameData _levelData;
    
    private float _time;

    private ObjectPool<Enemy> _pool;

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
        Enemy instance = Instantiate(_Enemies[Random.Range(0,2)].GetComponent<Enemy>(), transform.position, quaternion.identity);
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
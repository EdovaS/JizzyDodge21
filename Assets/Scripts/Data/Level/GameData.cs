using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 2)]
public class GameData : ScriptableObject
{
    [Header("Default Values", order = 0)]
    // ? Main Variables
    [SerializeField] private float _score;
    [SerializeField] private float _enemySpeed = -10;
    [SerializeField] private float _timeBetweenSpawn = 1.5f;
    [SerializeField] public float MinimumTimeBetweenSpawn = 0.3f;
    
    private float _hit;
    

    // ? Set value Functions
    #region Set value Functions

    public void SetScore(float value) => _score = value;
    public void SetEnemySpeed(float value) => _enemySpeed = value;
    public void SetTimeBetweenSpawn(float value) => _timeBetweenSpawn = value;
    public void SetHit(float value) => _hit = value;

    #endregion
    
    // ? Add value Functions
    #region Add value Functions

    public void AddToScore(float value) => _score += value;
    public void AddToEnemySpeed(float value) => _enemySpeed += value;
    public void AddToTimeBetweenSpawn(float value) => _timeBetweenSpawn -= value;
    public void AddToHit(float value) => _hit += value;

    #endregion
    
    // ? Get Value Functions
    #region Get Value Functions

    public float GetScore() { return _score; }
    public float GetEnemySpeed() { return _enemySpeed;}
    public float GetTimeBetweenSpawn() { return _timeBetweenSpawn;}
    public float GetHit() { return _hit; }

    #endregion

    [Header("Difficulty Values", order = 1)]
    public float EnemySpeedIncrement;
    public float TimeBetweenSpawnDecrement;

    [Header("Every X Hit", order = 2)] public int EveryHit;

}

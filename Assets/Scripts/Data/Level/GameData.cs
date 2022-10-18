using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 2)]
public class GameData : ScriptableObject
{
    [Header("Readonly Variables", order = 0)]
    // ? Main Variables
    [ReadOnly] [SerializeField] private float _score;
    [ReadOnly] [SerializeField] private float _enemySpeed = -10;
    [ReadOnly] [SerializeField] private float _timeBetweenSpawn = 1.5f;
    
    [Header("Minimum Values", order = 1)]
    [SerializeField] public float MinimumTimeBetweenSpawn = 0.3f;
    [SerializeField] public float MaxEnemySpeed;

    [Header("Starting Values", order = 2)] 
    public float StartingEnemySpeed;
    public float StartingTimeBetweenSpawn;
    public float MaxScore;

    [Header("Number of Enemies this level.", order = 3)] // Used at a max random value for enemy spawning;
    public int MaxNumberOfEnemies; 
    
    private float _hit;
    
    [Header("Difficulty Values", order = 4)]
    public float EnemySpeedIncrement;
    public float TimeBetweenSpawnDecrement;

    [Header("Every X Hit Difficulty Increases", order = 2)] public int EveryHit;
    

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

}

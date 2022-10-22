using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStateCol : MonoBehaviour
{
    private readonly string _defaultState = "DefaultState";
    private readonly string _stateX = "StateOne";
    private readonly string _stateY = "StateSecond";

    [SerializeField] private Shake _shakeScript;

    enum PlayerState
    {
        DefaultState,
        StateX,
        StateY
    }

    private PlayerState _playerState;
    
    [FormerlySerializedAs("_BlueParticleEffect")] [SerializeField] private GameObject _xEnemyParticleEffect;
    [FormerlySerializedAs("_RedParticleEffect")] [SerializeField] private GameObject _yEnemyParticleEffect;
    [SerializeField] private GameObject _zEnemyParticleEffect;

    [SerializeField] private Animator _animator;

    [Header("Events")] public GameEvent onScoreIncreased;
    public GameEvent onGameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == _defaultState) _playerState = PlayerState.DefaultState;
        if (gameObject.name == _stateX) _playerState = PlayerState.StateX;
        if (gameObject.name == _stateY) _playerState = PlayerState.StateY;
        
        switch (_playerState)
        {
            case PlayerState.DefaultState:
                if (other.CompareTag("EnemyOne") || other.CompareTag("EnemySecond")) GameOver();
                if (other.CompareTag("EnemyDefault")) EnemyKill(_zEnemyParticleEffect, other);
                break;
            
            case PlayerState.StateX:
                if (other.CompareTag("EnemyOne")) EnemyKill(_xEnemyParticleEffect, other);
                if (other.CompareTag("EnemyDefault")) GameOver();
                break;
            
            case PlayerState.StateY:
                if (other.CompareTag("EnemySecond")) EnemyKill(_yEnemyParticleEffect, other);
                if (other.CompareTag("EnemyDefault")) GameOver();
                break;
                
        }
    }

    private void GameOver()
    {
        GameObject playerParentGameObject = transform.parent.gameObject;
        
        // Player Die
        //playerParentGameObject.SetActive(false);

        // Actual Game Over event send.
        onGameOver.Raise();

        // Screen Shake
        // Player Explode Effect

        playerParentGameObject.GetComponent<DieTweenPlayer>().PlayerDieEffect();


    }

    private void EnemyKill(GameObject enemyDieParticlePrefab, Collider2D other)
    {
        _animator.SetTrigger("Attack");
        _shakeScript.CamShake();

        // Play the particles
        enemyDieParticlePrefab.SetActive(true);
        enemyDieParticlePrefab.GetComponent<ParticleSystem>().Play();
                
        // Enemy Die Sound
        EnemyDieSound();

        // Event call send
        onScoreIncreased.Raise();

        var enemyTransform = other.gameObject.GetComponent<Transform>();
        enemyTransform.position = new Vector3(enemyTransform.position.x - 10, enemyTransform.position.y);
    }

    private static void EnemyDieSound()
    {
        int randomVal = Random.Range(1, 4);

        switch (randomVal)
        {
            case 1:
                SoundManager.PlaySound(SoundManager.Sound.EnemyDie1);
                break;
            case 2:
                SoundManager.PlaySound(SoundManager.Sound.EnemyDie2);
                break;
            case 3:
                SoundManager.PlaySound(SoundManager.Sound.EnemyDie3);
                break;
        }
    }
}

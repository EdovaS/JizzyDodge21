using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStateCol : MonoBehaviour
{
    private readonly string _defaultState = "DefaultState";
    private readonly string _stateOne = "StateOne";
    private readonly string _stateSecond = "StateSecond";

    [SerializeField] private Shake _shakeScript;
    

    [FormerlySerializedAs("_BlueParticleEffect")] [SerializeField] private GameObject _xEnemyParticleEffect;
    [FormerlySerializedAs("_RedParticleEffect")] [SerializeField] private GameObject _yEnemyParticleEffect;
    [SerializeField] private GameObject _zEnemyParticleEffect;

    [SerializeField] private Animator _animator;

    [Header("Events")] public GameEvent onScoreIncreased;
    public GameEvent onGameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == _defaultState)
        {
            if (other.CompareTag("EnemyOne") || other.CompareTag("EnemySecond"))
            {
                // Player Die
                transform.parent.gameObject.SetActive(false);

                onGameOver.Raise();
                
                // Screen Shake
                // Player Explode particle
            }
        }
        
        if (gameObject.name == _stateOne)
        {
            if (other.CompareTag("EnemyOne"))
            {
                _animator.SetTrigger("Attack");
                _shakeScript.CamShake();

                // Play the particles
                _xEnemyParticleEffect.SetActive(true);
                _xEnemyParticleEffect.GetComponent<ParticleSystem>().Play();
                
                // Enemy Die Sound
                EnemyDieSound();

                // Event call send
                onScoreIncreased.Raise();

                var enemyTransform = other.gameObject.GetComponent<Transform>();
                enemyTransform.position = new Vector3(enemyTransform.position.x - 10, enemyTransform.position.y);

            }
        }
        
        if (gameObject.name == _stateSecond)
        {
            if (other.CompareTag("EnemySecond"))
            {
                _animator.SetTrigger("Attack");
                _shakeScript.CamShake();
                
                // Play the Particle System
                _yEnemyParticleEffect.SetActive(true);
                _yEnemyParticleEffect.GetComponent<ParticleSystem>().Play();
                
                // Enemy Die Sound
                EnemyDieSound();

                // Event call send
                onScoreIncreased.Raise();
                
                var enemyTransform = other.gameObject.GetComponent<Transform>();
                enemyTransform.position = new Vector3(enemyTransform.position.x - 10, enemyTransform.position.y);
                
                
            }
        }
        
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

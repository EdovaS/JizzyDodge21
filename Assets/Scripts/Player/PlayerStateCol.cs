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

    [SerializeField] private Animator _animator;

    [Header("Events")] public GameEvent onScoreIncreased;
    public GameEvent onGameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == _defaultState)
        {
            if (other.CompareTag("EnemyOne") || other.CompareTag("EnemySecond"))
            {
                print("Lost a health or Game Over");
                transform.parent.gameObject.SetActive(false);
                
                onGameOver.Raise();
                
                // Screen Shake
                // Player Explode particle
                // Trigger game over animations - maybe using Event or lets see
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
                
                // Event call send
                onScoreIncreased.Raise();
                
                var enemyTransform = other.gameObject.GetComponent<Transform>();
                enemyTransform.position = new Vector3(enemyTransform.position.x - 10, enemyTransform.position.y);
                
                
            }
        }
    }
}

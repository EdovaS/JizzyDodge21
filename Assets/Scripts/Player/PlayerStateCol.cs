using System;
using System.Collections;
using UnityEngine;

public class PlayerStateCol : MonoBehaviour
{
    private readonly string _defaultState = "DefaultState";
    private readonly string _stateOne = "StateOne";
    private readonly string _stateSecond = "StateSecond";

    [SerializeField] private GameObject _BlueParticleEffect;
    [SerializeField] private GameObject _RedParticleEffect;
    [SerializeField] private Transform _particlePos;

    [SerializeField] private Animator _animator;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == _defaultState)
        {
            if (other.CompareTag("EnemyOne") || other.CompareTag("EnemySecond"))
            {
                print("Lost a health or Game Over");
                // Implement Lives 3
            }
        }
        
        if (gameObject.name == _stateOne)
        {
            if (other.CompareTag("EnemyOne"))
            {
                _animator.SetTrigger("Attack");
                // Instantiate the right Particle effect
                
                Instantiate(_BlueParticleEffect, _particlePos.position, Quaternion.identity);
                
                var enemyTransform = other.gameObject.GetComponent<Transform>();
                enemyTransform.position = new Vector3(enemyTransform.position.x - 10, enemyTransform.position.y);

            }
        }
        
        if (gameObject.name == _stateSecond)
        {
            if (other.CompareTag("EnemySecond"))
            {
                _animator.SetTrigger("Attack");
                
                // Instantiate the right Particle effect 
                Instantiate(_RedParticleEffect, _particlePos.position, Quaternion.identity);
                
                var enemyTransform = other.gameObject.GetComponent<Transform>();
                enemyTransform.position = new Vector3(enemyTransform.position.x - 10, enemyTransform.position.y);
                
                
            }
        }
    }
}

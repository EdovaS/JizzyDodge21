using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCol : MonoBehaviour
{
    private readonly string _defaultState = "DefaultState";
    private readonly string _stateOne = "StateOne";
    private readonly string _stateSecond = "StateSecond";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == _defaultState)
        {
            if (other.CompareTag("EnemyOne") || other.CompareTag("EnemySecond"))
            {
                print("Lost a health or Game Over");
            }
        }
        
        if (gameObject.name == _stateOne)
        {
            if (other.CompareTag("EnemyOne"))
            {
                var enemyTransform = other.gameObject.GetComponent<Transform>();
                enemyTransform.position = new Vector3(enemyTransform.position.x - 10, enemyTransform.position.y);
            }
        }
        
        if (gameObject.name == _stateSecond)
        {
            if (other.CompareTag("EnemySecond"))
            {
                var enemyTransform = other.gameObject.GetComponent<Transform>();
                enemyTransform.position = new Vector3(enemyTransform.position.x - 10, enemyTransform.position.y);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    // what is an delegate ? 
    // A delegate is a variable that holds function instead of data.
    public delegate void OnDisableCallback(Enemy instance); // ? This is a delegate
    public OnDisableCallback Disable; // ? This is an instance of the delegate 
    

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AddToPool"))
        {
            Disable?.Invoke(this);
        }
    }
}

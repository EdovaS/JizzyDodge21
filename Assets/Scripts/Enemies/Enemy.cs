using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
         
    }

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0,0);
    }
}

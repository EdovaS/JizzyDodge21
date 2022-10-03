using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent GameEvent;

    public UnityEvent Response;

    private void OnEnable() => GameEvent.RegisterListener(this);
    
    private void OnDisable() => GameEvent.UnRegisterListener(this);
    
    public void OnEventRaised() => Response.Invoke();
}

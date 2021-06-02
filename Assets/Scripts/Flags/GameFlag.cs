﻿using System;
using UnityEngine;

public abstract class GameFlag : ScriptableObject
{
    public event Action Changed;
    
    protected void SendChanged() => Changed?.Invoke();
}

public abstract class GameFlag<T> : GameFlag
{
    public T Value { get; protected set; }
    private void OnEnable() => Value = default;
    private void OnDisable() => Value = default;


    public void Set(T value)
    {
        Value = value;

        SendChanged();
    }
}
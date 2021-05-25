using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Bool Game Flag")]
public class GameFlag : ScriptableObject
{
    public static event Action AnyChanged;
    public bool Value { get; private set; }

    private void OnEnable() => Value = default;
    private void OnDisable() => Value = default;

    public void Set(bool value)
    {
        Value = value;

        AnyChanged?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Bool Game Flag")]
public class GameFlag : ScriptableObject
{
    public bool Value;

    private void OnEnable() => Value = default;
}

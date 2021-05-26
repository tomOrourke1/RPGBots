using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameFlagTriggerArea : MonoBehaviour
{
    [SerializeField] private BoolGameFlag boolGameFlag;
    private void OnTriggerEnter(Collider other)
    {
        boolGameFlag.Set(true);
    }
}
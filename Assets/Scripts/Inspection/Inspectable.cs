﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();
    public static event Action<bool> InspectablesInRangeChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inspectablesInRange.Remove(this);
            InspectablesInRangeChanged?.Invoke(_inspectablesInRange.Any());
        }
    }
}
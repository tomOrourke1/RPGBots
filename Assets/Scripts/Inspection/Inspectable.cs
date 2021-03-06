using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();
    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;
    public static event Action<bool> InspectablesInRangeChanged;


    [SerializeField] private float _timeToInspect = 3f;
    [SerializeField] private UnityEvent OnInspectionCompleted;
    
    InspectableData _data;
    private IMet[] _allConditions;
    public bool WasFullyInspected => InspectionProgress >= 1f;
    public float InspectionProgress => _data.TimeInspected / _timeToInspect;

    

    private void Awake() => _allConditions = GetComponents<IMet>();

    public void Bind(InspectableData inspectableData)
    {
        _data = inspectableData;
        if (_data.TimeInspected >= _timeToInspect)
        {
            CompleteInspection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && WasFullyInspected == false && MeetsConditions())
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }
    public bool MeetsConditions()
    {
        
        foreach (var condition in _allConditions)
        {
            if (condition.Met() == false)
                return false;
        }

        return true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_inspectablesInRange.Remove(this))
                InspectablesInRangeChanged?.Invoke(_inspectablesInRange.Any());
        }
    }

    public void Inspect()
    {
        if (WasFullyInspected)
            return;
        _data.TimeInspected += Time.deltaTime;
        if (_data.TimeInspected >= _timeToInspect)
        {
            CompleteInspection();
            
        }
    }

    void CompleteInspection()
    {
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged?.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
    }

   
}
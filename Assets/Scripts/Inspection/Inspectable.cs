using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();
    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;
    public static event Action<bool> InspectablesInRangeChanged;


    float _timeInspected;
    [SerializeField] private float _timeToInspect = 3f;
    [SerializeField] private UnityEvent OnInspectionCompleted;

    public bool WasFullyInspected { get; private set; }
    public float InspectionProgress => _timeInspected / _timeToInspect;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && WasFullyInspected == false)
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
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
        _timeInspected += Time.deltaTime;
        if (_timeInspected >= _timeToInspect)
        {
            CompleteInspection();
            
        }
    }

    void CompleteInspection()
    {
        WasFullyInspected = true;
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged?.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
    }

   
}
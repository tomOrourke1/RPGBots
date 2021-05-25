using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    [FormerlySerializedAs("_name")] [SerializeField] private string _displayName;
    [SerializeField] private string _description;

    [Tooltip("Designer / programmer notes, not visible to player.")]
    [SerializeField] private string _notes;

    [SerializeField] Sprite _strite;

    private int _currentStepIndex;
    
    public List<Step> Steps;


    public string Description => _description;
    public string DisplayName => _displayName;
    public Sprite Sprite => _strite;


    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            // do whatever we do when a quest progresses like update the UI
        }
    }

    private Step GetCurrentStep() => Steps[_currentStepIndex];
}

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;
    public string Instructions => _instructions;
    public List<Objective> objectives;


    public bool HasAllObjectivesCompleted()
    {
        return objectives.TrueForAll(t => t.IsCompleted);
    }
}

[Serializable]
public class Objective
{
    [SerializeField] private ObjectiveType _objectiveType;
    public enum ObjectiveType
    {
        Flag, 
        Item,
        Kill
    }

    public bool IsCompleted { get; }

    public override string ToString() => _objectiveType.ToString();
}

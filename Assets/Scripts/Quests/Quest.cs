using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public event Action Changed;
    
    
    [SerializeField] private string _displayName;
    [SerializeField] private string _description;

    [Tooltip("Designer / programmer notes, not visible to player.")]
    [SerializeField] private string _notes;

    [SerializeField] Sprite _strite;

    private int _currentStepIndex;
    
    public List<Step> Steps;


    public string Description => _description;
    public string DisplayName => _displayName;
    public Sprite Sprite => _strite;
    public Step CurrentStep => Steps[_currentStepIndex];

    private void OnEnable()
    {
        _currentStepIndex = 0;
        foreach (var step in Steps)
        {
            foreach (var objective in step.objectives)
            {
                if (objective.BoolGameFlag != null)
                {
                    objective.BoolGameFlag.Changed += HandleFlagChanged;
                }
                if (objective.IntGameFlag != null)
                {
                    objective.IntGameFlag.Changed += HandleFlagChanged;
                }
            }
        }
    }

    private void HandleFlagChanged()
    {
        TryProgress();
        Changed?.Invoke();
    }

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            Changed?.Invoke();
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
    [SerializeField] BoolGameFlag boolGameFlag;

    [Header("Int Game Flags")]
    [SerializeField] IntGameFlag intGameFlag;
    [Tooltip("Required amount for the counted integer game flag.")]
    [SerializeField] int _required;


    public BoolGameFlag BoolGameFlag => boolGameFlag;
    public IntGameFlag IntGameFlag => intGameFlag;
    
    public enum ObjectiveType
    {
        BoolFlag, 
        CountedIntFlag,
        Item,
        Kill
    }

    public bool IsCompleted
    {
        get
        {
            switch (_objectiveType)
            {
                case ObjectiveType.BoolFlag: return boolGameFlag.Value;
                case ObjectiveType.CountedIntFlag: return intGameFlag.Value >= _required;
                default: return false;
            }
        }
    }


    public override string ToString()
    {
        switch (_objectiveType)
        {
            case ObjectiveType.BoolFlag: return boolGameFlag.name;
            case ObjectiveType.CountedIntFlag: return $"{intGameFlag.name} ({intGameFlag.Value} / {_required})";
            default: return _objectiveType.ToString();
        }
        
    }
}

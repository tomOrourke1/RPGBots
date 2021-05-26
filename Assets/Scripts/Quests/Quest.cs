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
                if (objective.GameFlag != null)
                {
                    objective.GameFlag.Changed += HandleFlagChanged;
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
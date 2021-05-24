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

    public List<Step> Steps;


    public string Description => _description;
    public string DisplayName => _displayName;
    public Sprite Sprite => _strite;
}

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;
    public string Instructions => _instructions;
    public List<Objective> objectives;
    
    
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

    public override string ToString() => _objectiveType.ToString();
}

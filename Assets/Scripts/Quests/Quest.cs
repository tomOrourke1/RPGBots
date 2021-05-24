using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    
    [Tooltip("Designer / programmer notes, not visible to player.")]
    [SerializeField] private string _notes;
    
    public List<Step> Steps;
    
    
}

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;
    public List<Objective> objective;
    
    
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
}

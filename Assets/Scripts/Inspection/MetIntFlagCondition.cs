using UnityEngine;

public class MetIntFlagCondition : MonoBehaviour, IMet
{
    [SerializeField] private IntGameFlag _requiredFlag;
    [SerializeField] private int _requiredValue = 2;

    public bool Met() => _requiredFlag.Value >= _requiredValue;
}
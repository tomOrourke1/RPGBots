using UnityEngine;


public class MetInspectedCondition : MonoBehaviour, IMet
{

    [SerializeField] private Inspectable _requiredInspectable;
    
    public bool Met() => _requiredInspectable.WasFullyInspected;
}
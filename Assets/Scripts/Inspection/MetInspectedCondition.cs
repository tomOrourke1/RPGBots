using UnityEngine;



public class MetInspectedCondition : MonoBehaviour
{

    [SerializeField] private Inspectable _requiredInspectable;
    
    public bool Met() => _requiredInspectable.WasFullyInspected;
}
using UnityEngine;

public class GameFlagTriggerAreaForIntFlags : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private IntGameFlag _intGameFlag;
    private void OnTriggerEnter(Collider other) => _intGameFlag.Modify(_amount);
}
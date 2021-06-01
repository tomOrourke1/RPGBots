using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class FlagManager : MonoBehaviour
{
    [SerializeField] private List<GameFlag> _allFlags;
    public static FlagManager Instance { get; private set; }

    private void Awake() => Instance = this;

    public void Set(string flagName, string value)
    {
        var flag = _allFlags.FirstOrDefault(t => t.name.Replace(" ", "") == flagName);
        if (flag == null)
        {
            Debug.LogError($"Flag not found {flagName}");
            return;
        }

        if (flag is IntGameFlag intGameFlag)
        {
            if(int.TryParse(value, out var intGameValue))
                intGameFlag.Set(intGameValue);
        }
    }
}
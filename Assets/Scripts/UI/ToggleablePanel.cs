using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleablePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    static HashSet<ToggleablePanel> _visiblePanels = new HashSet<ToggleablePanel>();
    public static bool IsVisible => _visiblePanels.Count > 0;
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
        
    }
    
    public void Show()
    {
        _visiblePanels.Add(this);
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        _visiblePanels.Remove(this);
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
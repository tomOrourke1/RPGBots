using UnityEngine;

public class ToggleablePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
        
    }
    
    public void Show()
    {
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
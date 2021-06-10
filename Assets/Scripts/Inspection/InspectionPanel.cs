using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    [SerializeField] Image _progressBarFilledImage;
    [SerializeField] GameObject _progressBar;
    
    
    
    private void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
    }

    private void OnDisable()
    {
        Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;
    }

    private void UpdateHintTextState(bool enableHint)
    {
        _hintText.enabled = enableHint;
    }


    private void Update()
    {
        if (InspectionManager.Inspecting)
        {
            _progressBarFilledImage.fillAmount = InspectionManager.InspectionProgress;
            _progressBar.SetActive(true);
        }
        else if (_progressBar.activeSelf)
        {
            _progressBar.SetActive(false);
        }
    }
}
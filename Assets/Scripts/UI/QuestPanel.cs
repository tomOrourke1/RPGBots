using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ink.Parsed;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private Quest _selectedQuest;
    [SerializeField] private Step _selectedStep;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _currentObjectiveText;
    [SerializeField] private Image _iconImage;

    [ContextMenu("Bind")]
    public void Bind()
    {
        _iconImage.sprite = _selectedQuest.Sprite;
        _nameText.SetText(_selectedQuest.DisplayName);
        _descriptionText.SetText(_selectedQuest.Description);

        _selectedStep = _selectedQuest.Steps.FirstOrDefault();

        DisplayStemInstructionsAndObjectives();
    }

    private void DisplayStemInstructionsAndObjectives()
    {
        StringBuilder builder = new StringBuilder();
        if (_selectedStep != null)
        {
            builder.AppendLine(_selectedStep.Instructions);
            foreach (var objective in _selectedStep.objectives)
            {
                builder.AppendLine(objective.ToString());
            }
        }

        _currentObjectiveText.SetText(builder.ToString());
    }
}
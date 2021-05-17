using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] TextAsset _dialog;
    [SerializeField] TMP_Text _storyText;
    [SerializeField] Button[] _choiceButtons;
    private Story _story;


    // Start is called before the first frame update
    void Start()
    {
        _story = new Story(_dialog.text);
        RefreshView();
    }

    private void RefreshView()
    {
        StringBuilder storyTextBuilder = new StringBuilder();
        while (_story.canContinue)
        {
            storyTextBuilder.AppendLine(_story.Continue());
            
        }

        _storyText.SetText(storyTextBuilder);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

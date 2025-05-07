using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    Button recordButton;
    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        recordButton = transform.Find("RecordButton").GetComponent<Button>();

        recordButton.onClick.AddListener(OnClickRecordButton);
    }

    void OnClickRecordButton()
    {
        uiManager.OnClickRecord();
    }
    
}

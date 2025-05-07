using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : BaseUI
{
    Button yesButton;
    Button noButton;
    protected override UIState GetUIState()
    {
        return UIState.Event;
    }
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        yesButton = transform.Find("YesButton").GetComponent<Button>();
        noButton = transform.Find("NoButton").GetComponent<Button>();

        //yesButton.onClick.AddListener(OnClickYesButton);
        noButton.onClick.AddListener(OnClickNoButton);
    }

    //void OnClickYesButton()
    //{
     
    //}

    void OnClickNoButton()
    {

        uiManager.OnClickHome();
        Time.timeScale = 1f;
    }
}

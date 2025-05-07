using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTitleUI : MiniBaseUI
{
    Button playButton;
    Button exitButton;
    protected override UIState GetUIState()
    {
        return UIState.Title;
    }
    public override void Init(MiniUIManager uiManager)
    {
        base.Init(uiManager);
        playButton = transform.Find("PlayButton").GetComponent<Button>();

        playButton.onClick.AddListener(OnClickPlayButton);
    }


    void OnClickPlayButton()
    {
        miniUIManager.OnClickMiniGame();
        MiniGameManager.Instance.StartGame();
    }


}

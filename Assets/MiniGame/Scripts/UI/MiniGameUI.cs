using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameUI : MiniBaseUI
{
    TextMeshProUGUI score;
    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
    public override void Init(MiniUIManager uiManager)
    {
        base.Init(uiManager);
        score = transform.Find("ScoreText").GetComponentInChildren<TextMeshProUGUI>();

    }
    public void SetScore(int point)
    {
        score.text = point.ToString();
    }
}

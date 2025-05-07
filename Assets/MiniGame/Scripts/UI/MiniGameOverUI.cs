using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameOverUI : MiniBaseUI
{
    Button rePlayButton;
    Button exitButton;
    TextMeshProUGUI bestScore;
    TextMeshProUGUI currentScore;
    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
    public override void Init(MiniUIManager uiManager)
    {
        base.Init(uiManager);
        rePlayButton = transform.Find("RePlayButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();
        bestScore = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
        currentScore = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        rePlayButton.onClick.AddListener(OnClickRePlayButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }


    void OnClickRePlayButton()
    {
        miniUIManager.OnClickMiniGame();
    }
    void OnClickExitButton()
    {
        //저장 후 씬변경
    }
    public void UpdateScores(int best, int current)
    {
        if (bestScore != null) bestScore.text = best.ToString();
        if (currentScore != null) currentScore.text = current.ToString();
    }
}

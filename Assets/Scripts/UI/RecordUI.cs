using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordUI : BaseUI
{
    Button exitButton;
    TextMeshProUGUI highScoreText;
    protected override UIState GetUIState()
    {
        return UIState.Record;
    }
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        exitButton = transform.Find("ExitButton").GetComponent<Button>();
        highScoreText = transform.Find("HighScoreText").GetComponent<TextMeshProUGUI>();

        exitButton.onClick.AddListener(OnClickExitButton);
    }

    void OnClickExitButton()
    {
        uiManager.OnClickHome();
    }

    public void SetRecord(int bestScore)
    {
        Debug.Log("wwwwwwwwwwwwww"+bestScore);
        highScoreText.text = bestScore.ToString();
    }
}

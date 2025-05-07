using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class MiniUIManager : MonoBehaviour
{
    static MiniUIManager instance;
    public static MiniUIManager Instance
    {
        get { return instance; }
    }
    UIState currentState = UIState.Title;
    MiniTitleUI miniTitleUI = null;
    MiniGameUI miniGameUI = null;
    MiniGameOverUI miniGameOverUI = null;

    private void Awake()
    {
        instance = this;

        miniTitleUI = GetComponentInChildren<MiniTitleUI>(true);
        miniTitleUI?.Init(this);

        miniGameUI = GetComponentInChildren<MiniGameUI>(true);
        miniGameUI?.Init(this);

        miniGameOverUI = GetComponentInChildren<MiniGameOverUI>(true);
        miniGameOverUI?.Init(this);

        ChangeState(UIState.Title);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        miniTitleUI?.SetActive(currentState);
        miniGameUI?.SetActive(currentState);
        miniGameOverUI?.SetActive(currentState);
    }

    public void OnClickMiniTitle()
    {
        ChangeState(UIState.Title);
    }
    public void OnClickMiniGame()
    {
        ChangeState(UIState.Game);
    }
    public void OnClickMiniGameOver()
    {
        ChangeState(UIState.GameOver);
    }
    //실시간 점수갱신
    public void UpdateScore(int currentScore)
    {
        miniGameUI.SetScore(currentScore);
    }
}

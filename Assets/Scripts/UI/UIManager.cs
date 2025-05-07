using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.XR;


public enum UIState
{
    Home,
    Record,
    Event,
    Title,
    Game,
    GameOver
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }
    UIState currentState = UIState.Home;
    HomeUI homeUI = null;
    RecordUI recordUI = null;
    EventUI eventUI = null;

    private void Awake()
    {
        instance = this;

        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);

        recordUI = GetComponentInChildren<RecordUI>(true);
        recordUI?.Init(this);

        eventUI = GetComponentInChildren<EventUI>(true);
        eventUI?.Init(this);

        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        recordUI?.SetActive(currentState);
        eventUI?.SetActive(currentState);
    }

    public void OnClickRecord()
    {
        ChangeState(UIState.Record);
    }
    public void OnClickEvent()
    {
        ChangeState(UIState.Event);
    }
    public void OnClickHome()
    {
        ChangeState(UIState.Home);
    }
    public void UpdateHighScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        recordUI.SetRecord(bestScore);
    }
    private void OnEnable()
    {
        UpdateHighScore();
    }
}

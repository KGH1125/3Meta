using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{

    static MiniGameManager miniGameManager;
    public static MiniGameManager Instance { get { return miniGameManager; } }

    private int currentScore = 0;

    MiniUIManager miniUIManager;
    public MiniUIManager MiniUIManager { get { return miniUIManager; } }

    private int bestScore;
    public void Awake()
    {
        miniGameManager = this;
        miniUIManager = FindObjectOfType<MiniUIManager>();
    }
    private void Start()
    {
        Time.timeScale = 0f;

    }


    public void GameOver()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            PlayerPrefs.Save();
            bestScore = currentScore;
        }

        miniUIManager.OnClickMiniGameOver();

        MiniGameOverUI gameOverUI = FindObjectOfType<MiniGameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.UpdateScores(bestScore, currentScore);
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score : " + currentScore);
        miniUIManager.UpdateScore(currentScore);
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // 게임 진행 시작
        Debug.Log("Game Started");
    }
}

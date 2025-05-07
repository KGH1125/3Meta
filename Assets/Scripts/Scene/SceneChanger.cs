using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeMiniGame()
    {
        SceneManager.LoadScene("MiniGameScene");
    }
    public void ChangeMain()
    {

        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }
}

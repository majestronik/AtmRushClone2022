using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsRunning = false;
    public bool IsGameOver = false;
    public UIManager uiManager;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        uiManager.tapToPlayTxt.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        IsRunning = true;
        uiManager.tapToPlayTxt.gameObject.SetActive(false);
    }

    public void EndGameScene()
    {
        IsGameOver = true;
        uiManager.GameOverScene();
    }
}
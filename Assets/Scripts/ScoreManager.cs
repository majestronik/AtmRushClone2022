using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    public UIManager uiManager;

    public int totalMoney;
    public float score;

    // Start is called before the first frame update
    private void Awake()
    {
        score = 0;
        Init();
    }


    private void Init()
    {
        totalMoney = PlayerPrefs.GetInt("totalMoney");
        uiManager.totalMoney.text = totalMoney.ToString();
    }

    public void AddDeposit(int value)
    {
        totalMoney += value;
        score += value;
        uiManager.totalMoney.text = totalMoney.ToString();
        uiManager.currentMoney.text = score.ToString();
        PlayerPrefs.SetInt("totalMoney", totalMoney);
    }

    public void UpdateScoreText(float score = 0)
    {
        var _score = (int)score;
        uiManager.currentMoney.text = _score.ToString();
    }
}
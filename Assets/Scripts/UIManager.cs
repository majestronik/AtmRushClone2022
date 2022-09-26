using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI totalMoney;

    public TextMeshProUGUI currentMoney;

    public TextMeshProUGUI tapToPlayTxt;

    private Vector3 orgScale;

    private void Awake()
    {
        orgScale = tapToPlayTxt.transform.localScale;
        tapToPlayTxt.transform.DOScale(orgScale * 1.2f, 0.3f).SetLoops(-1, LoopType.Yoyo);
    }

    public void GameOverScene()
    {
        gameOverUI.SetActive(true);
    }
}
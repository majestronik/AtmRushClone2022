using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class FinishMoneyController : MonoBehaviour
{
    public GameManager gameManager;
    public ScoreManager scoreManager;
    public FinishCubeController finishCubeController;

    [Button]
    public void MoneyTower(float score)
    {
        float _score = 0;
        float duration = score / 10f;
        transform.DOMoveY(score / 30f, duration);
        finishCubeController.AddColorToCubes();

        DOTween.To(
                () => _score, x => _score = x, scoreManager.score, duration)
            .OnUpdate(
                () => { scoreManager.UpdateScoreText(_score); })
            .OnComplete(
                () =>
                {
                    gameManager.EndGameScene();
                });
    }
}
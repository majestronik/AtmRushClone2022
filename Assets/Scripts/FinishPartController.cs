using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FinishPartController : MonoBehaviour
{
    public FinishMoneyController finishMoneyController;
    public ScoreManager scoreManager;
    public Stacker stacker;
    public Transform topOfMoney;
    public CameraManager cameraManager;
    private bool _moneyAnimation;

    private void Awake()
    {
        _moneyAnimation = false;
    }

    public void EndgameAnimation()
    {
        PlayerController.instance.isMovement = false;
        PlayerController.instance.playerMesh.DOMoveX(0, .2f)
            .SetDelay(3f)
            .OnComplete(() =>
            {
                PlayerController.instance.playerMesh.DOMove(
                    new Vector3(PlayerController.instance.finishLine.position.x,
                        PlayerController.instance.playerMesh.position.y,
                        PlayerController.instance.finishLine.position.z), 2f);
            })
            .SetDelay(2)
            .OnComplete(() =>
            {
                PlayerController.instance.playerMesh.DOMove(
                        new Vector3(topOfMoney.position.x, PlayerController.instance.playerMesh.position.y + 0.2f,
                            topOfMoney.position.z),
                        1f).SetEase(Ease.OutQuad)
                    .OnComplete(() =>
                    {
                        PlayerController.instance.transform.SetParent(finishMoneyController.transform);
                        _moneyAnimation = true;
                        cameraManager.SwitchCamera("endGameCamera");
                        finishMoneyController.MoneyTower(scoreManager.score);
                    });
            });
    }

    private void Update()
    {
        if (_moneyAnimation)
        {
            StartCoroutine((topOfMoney.GetComponent<TopMoneyRaycast>().RaycastTarget()));
        }
    }
}
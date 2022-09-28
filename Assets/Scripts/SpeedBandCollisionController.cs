using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpeedBandCollisionController : MonoBehaviour
{
    public GameManager gameManager;
    private Stacker _stacker;
    private Transform _speedBandParent;
    private FinishPartController _finishPartController;

    private void Awake()
    {
        _stacker = GameObject.Find("Stacker").GetComponent<Stacker>();
        _speedBandParent = GameObject.Find("SpeedBandParent").transform;
        _finishPartController = GameObject.Find("FinishManager").GetComponent<FinishPartController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectableController>() != null)
        {
            var stackedList = _stacker._stackedObjects;
            var item = stackedList[stackedList.Count - 1];
            item.isCollected = false;
            if (stackedList.Count > 0)
            {
                CollectedItemAnimation(item);
                stackedList.Remove(item);
            }

            if (stackedList.Count == 0)
            {
                gameManager.IsRunning = false;
                PlayerController.instance.speedZ = 0f;
                _finishPartController.EndgameAnimation();
            }
        }
        else if (other.name == "Stacker")
        {
            PlayerController.instance.speedZ = 0f;
            _finishPartController.EndgameAnimation();
        }
    }

    private void CollectedItemAnimation(CollectableController item)
    {
        item.transform.SetParent(_speedBandParent);
        item.transform.DOLocalMoveZ(Random.Range(-0.2f, 0.2f), .5f);
        item.transform.DOLocalMoveX(-2f, .5f);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public enum AtmType
{
    Ingame,
    Endgame
}

public class DepositCollisionController : MonoBehaviour
{
    public ParticleSystem depositEffect;
    public AtmType atmType;
    public ScoreManager scoreManager;
    private Stacker _stacker;
    private ObstacleCollisionController _obstacleController;



    private void Awake()
    {
        _stacker = GameObject.Find("Stacker").GetComponent<Stacker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectableController>() != null)
        {
            switch (atmType)
            {
                case AtmType.Ingame:
                    for (int i = 0; i <= _stacker._stackedObjects.Count - 1; i++)
                    {
                        if (other.gameObject == _stacker._stackedObjects[i].gameObject)
                        {
                            AddDeposit(_stacker._stackedObjects[i].collectableItemType);
                            _stacker.PopFromIndex(i);
                            _stacker.SetRandomPositionToForward(i);
                            return;
                        }
                    }

                    break;
                case AtmType.Endgame:
                    AddDeposit(other.GetComponent<CollectableController>().collectableItemType);
                    Destroy(other.gameObject);
                    break;
            }
        }
    }

    public void AddDeposit(CollectableItemTypes depositedItemType)
    {
        depositEffect.Play();
        int value = 0;
        switch (depositedItemType.ToString())
        {
            case "Money":
                value = 1;
                break;
            case "Gold":
                value = 2;
                break;
            case "Diamond":
                value = 3;
                break;
        }

        scoreManager.AddDeposit(value);
    }
}
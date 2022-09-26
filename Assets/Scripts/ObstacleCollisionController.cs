using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObstacleCollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    private Stacker _stacker;
    private Transform _player;

    private void Awake()
    {
        _stacker = GameObject.Find("Stacker").GetComponent<Stacker>();
        _player = GameObject.Find("PlayerParent").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Stacker>() != null)
        {
            _stacker.PopFromIndex();
            PushPlayerToBackward();
        }

        if (other.GetComponent<CollectableController>() != null)
        {
            ExplodeItems(other);
        }
    }

    private void ExplodeItems(Collider other)
    {
        for (int i = 0; i <= _stacker._stackedObjects.Count - 1; i++)
        {
            if (_stacker._stackedObjects[i].gameObject != null)
            {
                if (other.gameObject == _stacker._stackedObjects[i].gameObject)
                {
                    _stacker.PopFromIndex(i);
                    _stacker.SetRandomPositionToForward(i);
                    return;
                }
            }
        }
    }

    private void PushPlayerToBackward()
    {
        var position = _player.position;
        PlayerController.instance.isMovement = false;
        _player.DOJump(new Vector3(position.x, position.y, position.z - 5f), .1f, 3, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => PlayerController.instance.isMovement = true);
    }
}
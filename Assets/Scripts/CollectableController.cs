using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public enum CollectableItemTypes
{
    Money,
    Gold,
    Diamond
}

public class CollectableController : MonoBehaviour
{
    public CollectableItemTypes collectableItemType;
    public bool isCollected;
    public List<GameObject> collectableItems;
    public float scaleMultiplier;
    public Vector3 originalScale;

    private bool _isAnimation;


    // Start is called before the first frame update
    private void OnValidate()
    {
        InitCollectableType();
    }

    private void Awake()
    {
        isCollected = false;
        scaleMultiplier = 1.2f;
        InitCollectableType();
        originalScale = transform.localScale;
    }

    public void InitCollectableType(bool changeIndex = false)
    {
        if (changeIndex && ((int)collectableItemType < Enum.GetNames(typeof(CollectableItemTypes)).Length - 1))
        {
            collectableItemType += 1;
            print(collectableItemType);
        }

        switch (collectableItemType)
        {
            case CollectableItemTypes.Money:
                collectableItems[0].SetActive(true);
                collectableItems[1].SetActive(false);
                collectableItems[2].SetActive(false);
                break;
            case CollectableItemTypes.Gold:
                collectableItems[0].SetActive(false);
                collectableItems[1].SetActive(true);
                collectableItems[2].SetActive(false);
                break;
            case CollectableItemTypes.Diamond:
                collectableItems[0].SetActive(false);
                collectableItems[1].SetActive(false);
                collectableItems[2].SetActive(true);
                break;
        }
    }

    public void ScaleAnimation(float duration)
    {
        if (_isAnimation) return;
        _isAnimation = true;
        transform.DOScale(originalScale * scaleMultiplier, duration)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => _isAnimation = false);
    }
}
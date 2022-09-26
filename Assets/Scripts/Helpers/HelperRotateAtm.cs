using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HelperRotateAtm : MonoBehaviour
{
    private void Awake()
    {
        transform.DORotate(new Vector3(0, 360f, 0f), 2f, RotateMode.Fast)
            .SetLoops(-1)
            .SetEase(Ease.Linear)
            .SetRelative();
    }
}
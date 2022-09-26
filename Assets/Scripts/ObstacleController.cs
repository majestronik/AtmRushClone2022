using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public enum Type
{
    Rotate,
    Move,
}

public class ObstacleController : MonoBehaviour
{
    public float duration;
    public Type type;
    public bool XAxis;
    public bool YAxis;
    public bool ZAxis;
    [Range(-360f, 360f)] public float degree;

    public bool isRelative;
    // public bool playOnAwake;

    private void Awake()
    {
        switch (type)
        {
            case Type.Rotate:
                Sequence mySequence;
                if (YAxis)
                {
                    mySequence = DOTween.Sequence();
                    mySequence.Append(transform.DORotate(new Vector3(0f, degree, 0f), duration, RotateMode.FastBeyond360)
                        .SetEase(Ease.OutSine));
                    mySequence.SetLoops(-1, LoopType.Yoyo);
                }
                else
                {
                    mySequence = DOTween.Sequence();
                    mySequence.Append(transform.DORotate(new Vector3(0f, 0f, degree), duration)
                        .SetEase(Ease.OutSine));
                    mySequence.SetLoops(-1, LoopType.Yoyo);
                }


                break;


            case Type.Move:
                transform.DOMoveX(degree, duration)
                    .SetEase(Ease.Linear)
                    .SetDelay(1f)
                    .SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }
}
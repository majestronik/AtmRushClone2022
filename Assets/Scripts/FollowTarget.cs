using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private bool x, y, z;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _offset = transform.position - _targetPosition;
    }

    void Update()
    {
        _targetPosition = transform.position;
        if (x)
        {
            _targetPosition.x = targetTransform.position.x + _offset.x;
        }

        if (y)
        {
            _targetPosition.y = targetTransform.position.y + _offset.y;
        }

        if (z)
        {
            _targetPosition.z = targetTransform.position.z + _offset.z;
        }

        transform.position = _targetPosition;
    }
}
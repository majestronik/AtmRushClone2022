using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _parentTargetPosition;
    private Vector3 _meshTargetLocalPosition;
    private Vector3? _lastMousePosition;

    public GameManager gameManager;
    public Transform playerMesh;
    public Transform finishLine;
    public Transform topOfMoney;
    public float speedZ;
    public float defaultSpeed;
    public float roadWidth, roadOffset;
    public static PlayerController instance;
    public bool isMovement;

    private void Awake()
    {
        Singleton();
        isMovement = true;
        defaultSpeed = speedZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsRunning)
        {
            speedZ = 8f;
            Movement();
        }
        else
        {
            speedZ = 0f;
        }
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lastMousePosition = null;
        }

        _parentTargetPosition = transform.position;
        _meshTargetLocalPosition = playerMesh.localPosition;

        _parentTargetPosition.z += Time.deltaTime * speedZ;

        // x axis
        if (isMovement)
        {
            if (_lastMousePosition != null)
            {
                float diff = (Input.mousePosition.x - _lastMousePosition.Value.x) * Time.deltaTime;
                _meshTargetLocalPosition.x += diff;
                _meshTargetLocalPosition.x = Mathf.Clamp(_meshTargetLocalPosition.x + diff,
                    -(roadWidth / 2) + roadOffset,
                    roadWidth / 2 - roadOffset);
                _lastMousePosition = Input.mousePosition;
            }
            speedZ = defaultSpeed;
        }
        else
        {
            speedZ = 0f;
        }

        transform.position = _parentTargetPosition;
        playerMesh.localPosition = _meshTargetLocalPosition;
    }


    private void Singleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
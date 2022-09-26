using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("mainCamera");
    }

    public void SwitchCamera(string cameraName)
    {
        _animator.Play(cameraName);
    }
}
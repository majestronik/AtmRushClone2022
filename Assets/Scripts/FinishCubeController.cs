using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using TMPro;

public class FinishCubeController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform finishCube;
    public List<Transform> TowerCubes;
    public int count;


    private void Awake()
    {
        CreateCubes();
    }

    [Button]
    public void CreateCubes()
    {
        for (int i = 0; i < count; i++)
        {
            var t = Instantiate(finishCube, transform.position + Vector3.up * 25f * 0.04f * i, Quaternion.identity,
                transform);
            t.gameObject.SetActive(true);
            // t.GetComponent<Renderer>().material.color = Color.HSVToRGB(i * (1.0f / count), .67f, .94f);
            t.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1) * 0.1f + " x";
            TowerCubes.Add(t);
        }
    }

    public void AddColorToCubes()
    {
        for (int i = 0; i < TowerCubes.Count; i++)
        {
            TowerCubes[i].GetComponent<Renderer>().material.color =
                Color.HSVToRGB(i * (1.0f / TowerCubes.Count), .67f, .94f);
        }
    }

    public static void TowerAnimation(Transform t, bool scale)
    {
        if (scale)
        {
            t.DOLocalMoveZ(-2f, .2f);
        }
        else
        {
            t.DOLocalMoveZ(0f, .2f);
        }
    }
}
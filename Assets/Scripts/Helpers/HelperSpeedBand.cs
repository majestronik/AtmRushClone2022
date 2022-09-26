using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HelperSpeedBand : MonoBehaviour
{
    private float offsetY;
    private bool _isAnim;

    private void Awake()
    {
        _isAnim = true;
        offsetY = 0f;
        StartCoroutine(SpeedBandAnim());
    }

    IEnumerator SpeedBandAnim()
    {
        while (_isAnim)
        {
            DOTween.To(() => offsetY, x => offsetY = x, -999f, 999);
            gameObject.GetComponent<Renderer>().materials[0].mainTextureOffset = new Vector2(0, offsetY);
            yield return new WaitForSeconds(.05f);
        }
    }
}
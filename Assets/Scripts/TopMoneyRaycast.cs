using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class TopMoneyRaycast : MonoBehaviour
{
    // Update is called once per frame

    private Transform _lastTransform;
    private Transform _currentTransform;

    public IEnumerator RaycastTarget()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            _lastTransform = (hit.transform);
            if (_currentTransform == null)
            {
                _currentTransform = (hit.transform);
            }

            if (_currentTransform != _lastTransform)
            {
                FinishCubeController.TowerAnimation(_lastTransform, true);
                FinishCubeController.TowerAnimation(_currentTransform, false);
                _currentTransform = _lastTransform;
            }
        }

        yield return new WaitForSeconds(.1f);
    }
}
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using DG.Tweening;

public class Stacker : MonoBehaviour
{
    public List<CollectableController> _stackedObjects = new List<CollectableController>();

    public float stackFollowSpeed;
    public Transform stackHead;
    public Transform stackParent;
    public Vector3 stackOffset;
    public ParticleSystem destroyEffect;


    // Update is called once per frame
    void Update()
    {
        transform.localPosition = stackHead.localPosition;
        StackMechanic();
    }

    private void StackMechanic()
    {
        for (int i = 0; i < _stackedObjects.Count; i++)
        {
            if (_stackedObjects[i] == null) _stackedObjects.Remove(_stackedObjects[i]);
            _stackedObjects[i].transform.position = Vector3.Lerp(_stackedObjects[i].transform.position,
                GetFollowTarget(i), Time.deltaTime * stackFollowSpeed);
        }
    }

    private Vector3 GetFollowTarget(int index)
    {
        if (index == 0)
            return stackHead.position + stackOffset;
        return _stackedObjects[index - 1].transform.position + stackOffset;
    }

    public void AddToStack(Collider c)
    {
        _stackedObjects.Add(c.GetComponent<CollectableController>());
        c.GetComponent<CollectableController>().isCollected = true;
        c.transform.SetParent(stackParent);
        Vector3 pos = c.transform.position;
        pos.y = .5f;
        c.transform.position = pos; 
        WaveScale();
    }

    private void WaveScale()
    {
        StartCoroutine(WaveScaleCoroutine());
    }

    IEnumerator WaveScaleCoroutine()
    {
        if (_stackedObjects.Count > 8)
        {
            for (int i = 8; i >= 0; i--)
            {
                _stackedObjects[i].ScaleAnimation(.1f);
                yield return new WaitForSeconds(.05f);
            }
        }
        else
        {
            for (int i = _stackedObjects.Count - 1; i >= 0; i--)
            {
                _stackedObjects[i].ScaleAnimation(.1f);
                yield return new WaitForSeconds(.05f);
            }
        }
    }

    public void PopFromIndex(int index = 0)
    {
        if (_stackedObjects.Count > 0)
        {
            GameObject coinEffect = Instantiate(destroyEffect.gameObject, _stackedObjects[index].transform.position,
                Quaternion.identity);
            Destroy(_stackedObjects[index].gameObject);
            Destroy(coinEffect, destroyEffect.main.duration);
            _stackedObjects.RemoveAt(index);
        }
    }

    public void SetRandomPositionToForward(int index = 0)
    {
        for (int j = _stackedObjects.Count - 1; j > index; j--)
        {
            Transform obj = _stackedObjects[j].transform;
            obj.SetParent(GameObject.Find("CollectableItems").transform);
            _stackedObjects.RemoveAt(j);
            obj.GetComponent<CollectableController>().isCollected = true;

            var position = obj.position;
            var positionX = position.x;
            var positionY = position.y;
            var positionZ = position.z;


            float x = Random.Range(-(PlayerController.instance.roadWidth / 2 - PlayerController.instance.roadOffset),
                (PlayerController.instance.roadWidth / 2 - PlayerController.instance.roadOffset));
            float z = Random.Range(positionZ + 5f, positionZ + 7f);

            obj.transform.DOMove(new Vector3(x, .5f, z), .2f)
                .OnComplete(() =>
                {
                    obj.transform.localScale = obj.GetComponent<CollectableController>().originalScale;
                    obj.transform.DOJump(obj.position, .5f, 1, 0.3f);
                    obj.GetComponent<CollectableController>().isCollected = false;
                });
        }
    }
}
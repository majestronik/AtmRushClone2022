using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectableController>() != null)
        {
            var item = other.GetComponent<CollectableController>();
            item.InitCollectableType(true);
        }
    }
}
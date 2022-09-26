using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollisionController : MonoBehaviour
{
    public Stacker playerStacker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectableController>() != null &&
            other.GetComponent<Transform>().parent.name != "SpeedBandParent")
        {
            if (!other.GetComponent<CollectableController>().isCollected)
            {
                playerStacker.AddToStack(other);
            }
        }
    }
    
}
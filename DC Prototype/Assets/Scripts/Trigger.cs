﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int layerToEnter;
    public int layerToExit;

    // quick detection and changing of the physics layer
    private void OnTriggerEnter(Collider col)
    {
        // swaps object colliding with trigger's layer to the layertoenter
        col.gameObject.layer = layerToEnter;
    }

    private void OnTriggerExit(Collider col)
    {
        // swaps object colliding with trigger's layer to the layertoexit
        col.gameObject.layer = layerToExit;
    }
}

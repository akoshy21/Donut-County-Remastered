using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    public int layerToEnter;
    public int layerToExit;

    private void OnTriggerEnter(Collider col)
    {
        col.gameObject.layer = layerToEnter;
    }

    private void OnTriggerExit(Collider col)
    {
        col.gameObject.layer = layerToExit;
    }
}

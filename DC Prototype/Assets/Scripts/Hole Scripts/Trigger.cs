using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int layerToEnter;
    public int layerToExit;

    public GameObject hm;

    // quick detection and changing of the physics layer
    private void OnTriggerEnter(Collider col)
    {
        // Debug.Log("in + " + col.gameObject.tag);

        // if the object is tagged water, then st waterfill to true, and add
        // water to the list of objects in the hole
        if (col.gameObject.tag.Equals("water"))
        {

            Debug.Log("watered: " + col.gameObject.name);
            hm.GetComponent<HoleManager>().waterFill = true;
            Debug.Log("waterfill " + hm.GetComponent<HoleManager>().waterFill);
            hm.GetComponent<HoleManager>().insideHole.Add(col.gameObject);
        }
        else
        {
            // swaps object colliding with trigger's layer to the layertoenter
            col.gameObject.layer = layerToEnter;
            //Debug.Log("enter hole");

        }
    }

    private void OnTriggerExit(Collider col)
    {
        // swaps object colliding with trigger's layer to the layertoexit
        col.gameObject.layer = layerToExit;
    }
}

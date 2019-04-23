using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    // THIS SCRIPT GOES ON THINGS THAT ARE EATABLE.

    public float calories; // The size of the object; corresponds to the increase in size of the hole
    public bool launchable; // Can it be catapulted?
    public bool magnetic = true; // can the hole's artificial gravity affect it.
    public Vector3 com; // what is the object's center of mass

    private void Awake()
    {
        // set the gameobject's tag to eatable
        this.gameObject.tag = "eatable";
    }

    private void Start()
    {
        // set magnetic to true, and get the center of mass
        magnetic = true;
        com = GetComponent<Rigidbody>().centerOfMass;
    }

}

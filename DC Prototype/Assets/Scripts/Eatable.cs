using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    // THIS SCRIPT GOES ON THINGS THAT ARE EATABLE.

    // The size of the object; corresponds to the increase in size of the hole
    public float calories;
    // Can it be catapulted?
    public bool launchable;

    public bool magnetic = true;
    public Vector3 com;

    private void Awake()
    {
        this.gameObject.tag = "eatable";
    }

    private void Start()
    {
        magnetic = true;
        com = GetComponent<Rigidbody>().centerOfMass;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    // THIS SCRIPT GOES ON THINGS THAT ARE EATABLE.

    // The size of the object; corresponds to the increase in size of the hole
    public int calories;
    public bool launchable;
    public bool magnetic = true;
    public Vector3 com;

    private void Start()
    {
        this.gameObject.tag = "eatable";
        magnetic = true;
        com = GetComponent<Rigidbody>().centerOfMass;
    }

}

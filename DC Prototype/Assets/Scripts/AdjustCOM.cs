using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCOM : MonoBehaviour
{
    public Vector3 centerOfMass;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }
}


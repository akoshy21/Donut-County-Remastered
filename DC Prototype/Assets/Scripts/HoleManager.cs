using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public float speedMod;
    public float holeSize = 1;
    public List<GameObject> insideHole = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        // simple movement system to shift our hole around
        this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speedMod;
        
    }

    public void Grow()
    {
        // scales the hole to the holeSize
        Vector3 modSize = new Vector3(holeSize,0,holeSize);

        transform.localScale += modSize * 0.1f;
    }
    public void Shrink()
    {
        // scales the hole to the holeSize
        Vector3 modSize = new Vector3(holeSize, 0, holeSize);

        transform.localScale -= modSize * 0.1f;
    }
}

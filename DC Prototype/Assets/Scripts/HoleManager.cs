using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public float speedMod;
    private int holeSize;
    public List<GameObject> insideHole;

    // Update is called once per frame
    void Update()
    {
        // simple movement system to shift our hole around
        this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speedMod;
    }

    public void Grow(int objectSize)
    {
        Vector3 origSize = this.gameObject.transform.localScale;

        this.gameObject.transform.localScale = (1 + (objectSize * 0.1f)) * origSize;
    }
}

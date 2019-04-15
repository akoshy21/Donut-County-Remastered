﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public float speedMod;
    public float holeSize = 1;
    public List<GameObject> insideHole = new List<GameObject>();
    public Vector3 origPos;
    public bool waterFill;
    public GameObject water;

    private void Start()
    {
        origPos = this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        // simple movement system to shift our hole around
        this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speedMod;
        if(origPos != this.transform.position)
        {
            UpdateColliders();
            origPos = transform.position;
        }

        if(waterFill)
        {
            water.SetActive(true);
        }
    }

    public void Grow()
    {
        // scales the hole to the holeSize
        Vector3 modSize = new Vector3(holeSize,0,holeSize);

        transform.localScale += modSize * 0.1f;
    }

    void UpdateColliders()
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, holeSize))
        {
            col.enabled = false;
            col.enabled = true;
        }
    }

    public void Shrink()
    {
        // scales the hole to the holeSize
        Vector3 modSize = new Vector3(holeSize, 0, holeSize);

        transform.localScale -= modSize * 0.1f;
    }

    //public void ChangeSize(float holeMod)
    //{
    //    holeSize += holeMod;

    //    Vector3 modSize = new Vector3(holeMod, 0, holeMod);
    //    transform.localScale += modSize;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    //button rect transform should mirror raw image rect transform

    private RectTransform myRect;
    public RectTransform myImg;

    void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        myRect.sizeDelta = myImg.sizeDelta;
    }
}

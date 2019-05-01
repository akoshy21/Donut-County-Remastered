using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerRotation : MonoBehaviour
{
    private RectTransform myRect;
    public float speed;

    void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        myRect.Rotate(new Vector3( 0, 0, (speed * Time.deltaTime)));
    }
}

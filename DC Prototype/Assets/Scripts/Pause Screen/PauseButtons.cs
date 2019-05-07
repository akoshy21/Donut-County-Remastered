using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseButtons : MonoBehaviour
{
    private RectTransform button;
    Vector2 currentSize;

    float x;
    float y;
    

    private void Start()
    {
        button = GetComponent<RectTransform>();
        currentSize = new Vector2(x, y);

        currentSize = GetComponent<RectTransform>().sizeDelta;
        
    }

    private void OnMouseOver()
    {
        Debug.Log("mouseover working");

        x = x * 1.5f;
        y = y * 1.5f;
    }
}

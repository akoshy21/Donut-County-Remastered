using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{

    Vector2 currentSize;
    

    private void Start()
    {
        currentSize = GetComponent<RectTransform>().sizeDelta = new Vector2();
        
    }

    private void OnMouseOver()
    {
        currentSize = new Vector2(currentSize.x * 1.5f, currentSize.y * 1.5f);
    }
}

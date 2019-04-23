using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{
    

    private void Start()
    {
        
    }

    private void OnMouseOver()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2();
    }
}

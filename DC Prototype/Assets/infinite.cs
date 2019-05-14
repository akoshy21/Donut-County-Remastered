using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinite : MonoBehaviour
{
    public GameObject infinitePuddle;

    private void Update()
    {
        if (!infinitePuddle.active)
        {
            infinitePuddle.SetActive(true);
        }
    }
}

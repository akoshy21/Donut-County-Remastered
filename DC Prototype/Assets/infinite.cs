using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinite : MonoBehaviour
{
    public GameObject infinitePuddle;
    public bool puddle;

    public static infinite inf;

    private void Awake()
    {
        inf = this;
    }

    private void Update()
    {
        if (!infinitePuddle.active && puddle)
        {
            infinitePuddle.SetActive(true);
        }
    }
}

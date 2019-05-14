using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinite : MonoBehaviour
{
    private void OnDestroy()
    {
        Instantiate(this);
    }
}

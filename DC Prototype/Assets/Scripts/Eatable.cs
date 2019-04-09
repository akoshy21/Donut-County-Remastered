using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{

    public int calories;

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.name);
    }
}

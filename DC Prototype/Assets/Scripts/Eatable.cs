using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{

    public int size;

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.name);
    }
}

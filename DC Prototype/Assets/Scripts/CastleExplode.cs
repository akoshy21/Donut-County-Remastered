using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleExplode : MonoBehaviour
{

    public float power;
    public Vector3 explosionPos;
    public float radius;

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("POW");
            // Explode();
        }
    }

    public void Explode()
    {
        GameObject[] castlebits = GameObject.FindGameObjectsWithTag("castleBits");

        foreach(Transform bit in transform)
        {
            bit.parent = null;

            bit.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            bit.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0,1),Random.Range(0, 1),Random.Range(0, 1)) * power, ForceMode.Acceleration);

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle_Launch : MonoBehaviour
{

    public Vector3 launchDir;
    public float launchForce;
    Rigidbody rb;
    MeshCollider mc;
    bool esploded = false;
    public bool explode;
    float colliderCount = 60;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (explode && esploded == false)
        {
            esploded = true;
            rb.isKinematic = false;
            rb.AddForce(launchDir * launchForce, ForceMode.Impulse);
           // mc = gameObject.AddComponent<MeshCollider>();
           // mc.convex = true;
        }
        if(esploded)
        {
            if (colliderCount > 0)
            {
                colliderCount -= 1;
            }
            else if (colliderCount == 0)
            {
                //rb.isKinematic = true;
                mc = gameObject.AddComponent<MeshCollider>();
                mc.convex = true;
                colliderCount = -1;
               // rb.isKinematic = false;
            }
            rb.velocity.Normalize();
        }
    }
}

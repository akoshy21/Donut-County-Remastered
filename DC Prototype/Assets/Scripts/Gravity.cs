using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravRadius = 2;
    public float gravForce = 1;

    public List<Collider> attracted = new List<Collider>();

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, gravRadius))
        {
            //check distance from target to the hole
            Vector3 forceDirection = transform.position - collider.transform.position;

            //apply gravity on object as a force in the direction of the hole
            if (collider.gameObject.tag.Equals("eatable") && collider.gameObject.GetComponent<Eatable>().magnetic)
            {
                collider.gameObject.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * gravForce * Time.fixedDeltaTime);
                attracted.Add(collider);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        // check if object is eatable; if so, set its magnetic quality to false on enter.
        if (col.gameObject.tag.Equals("eatable"))
        {
            col.gameObject.GetComponent<Eatable>().magnetic = false;
        }
    }
}

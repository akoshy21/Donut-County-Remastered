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
            //check distance from target
            Vector3 forceDirection = transform.position - collider.transform.position;

            //apply gravity on object
            if (collider.gameObject.tag.Equals("eatable") && collider.gameObject.GetComponent<Eatable>().magnetic)
            {
                collider.gameObject.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * gravForce * Time.fixedDeltaTime);

                //collider.gameObject.GetComponent<Rigidbody>().centerOfMass = transform.position;
                Debug.Log("tug: " + collider.gameObject.name + " " + forceDirection);

                attracted.Add(collider);
            }
        }

        //foreach (Collider col in attracted)
        //{
        //    if(Vector3.Distance(col.gameObject.transform.position, transform.position) > gravRadius)
        //    {
        //        GetComponent<Collider>().gameObject.GetComponent< Rigidbody > ().centerOfMass = GetComponent<Collider>().gameObject.GetComponent<Eatable>().com;
        //    }
        //}
    }

    private void OnTriggerEnter(Collider col)
    {
        col.gameObject.GetComponent<Eatable>().magnetic = false;
    }
}

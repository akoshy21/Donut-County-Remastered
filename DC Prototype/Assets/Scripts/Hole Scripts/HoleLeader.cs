using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleLeader : MonoBehaviour
{
    public Camera cam;
    public float speedMod;
    public GameObject hole;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = hole.transform.position;

    }

    private void FixedUpdate()
    {
        // send out a ray to check where the mouse is and move the hole toward that point based on the speed mod
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Default layer ensures that only the floor impacts our hole position
        if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Default")))
        {
            Vector3 objectHit = new Vector3(hit.point.x, hit.point.y - 0.7396f, hit.point.z);
            objectHit.y = this.transform.position.y; // y is preset by us.


            Vector3 dir = objectHit - transform.position;

            if (Mathf.Abs(Vector3.Distance(objectHit, transform.position)) > 0.5f)
            {
                this.GetComponent<Rigidbody>().MovePosition(this.transform.position + dir.normalized * speedMod * Time.deltaTime);
            }
            else if (Mathf.Abs(Vector3.Distance(objectHit, transform.position)) > 0.1f)
            {
                this.GetComponent<Rigidbody>().MovePosition(this.transform.position + dir.normalized *(speedMod/2) * Time.deltaTime);
            }
            //if(movement.magnitude > dir.magnitude)
            //{
            //    movement = new Vector3(dir.x, -0.12f, dir.z);
            //}

            //GetComponent<CharacterController>().Move(movement);
            //transform.position = Vector3.MoveTowards(this.transform.position, objectHit, speedMod * Time.deltaTime);
        }

    }
    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.name);
    }
}

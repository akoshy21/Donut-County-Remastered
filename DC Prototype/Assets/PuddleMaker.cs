using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleMaker : MonoBehaviour
{
    public GameObject puddle;
    public GameObject fish;
    public bool launched;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("surface") && launched)
        {
            Instantiate(puddle, new Vector3(this.transform.position.x, -0.6f, this.transform.position.z), Quaternion.identity);

            if (this.gameObject.tag.Equals("fish"))
            {
                Debug.Log("FISHY");
                Instantiate(fish, new Vector3(this.transform.position.x, -0.5f, this.transform.position.z), Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}

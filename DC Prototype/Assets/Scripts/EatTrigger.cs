using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatTrigger : MonoBehaviour
{
    public GameObject hole;
    public HoleManager hm;

    void Start()
    {
        hole = GameObject.FindGameObjectWithTag("Hole");
        hm = hole.GetComponent<HoleManager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        //if the gameobject colliding is eatable, add to the hole size, grow the hole, and destroy the gameobject
        if(col.gameObject.tag == "eatable")
        {
            hm.holeSize += col.gameObject.GetComponent<Eatable>().calories;
            hm.Grow();

            //check if it can be launched, and set the gameobject to false if it can;
            if (col.GetComponent<Eatable>().launchable)
            {
                hm.insideHole.Add(col.gameObject);
                col.gameObject.SetActive(false);
            }
            else
            {
                Destroy(col.gameObject);
            }
        }
    }
}

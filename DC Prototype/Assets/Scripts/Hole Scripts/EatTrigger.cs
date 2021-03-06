﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatTrigger : MonoBehaviour
{

    public GameObject hole;
    public HoleManager hm;

    private void Start()
    {
        // on start, set the hole to the hole and hole manager to its hole manager component
        hole = GameObject.FindGameObjectWithTag("Hole");
        hm = hole.GetComponent<HoleManager>();
    }

    private void Update()
    {
        // finds all eatable objects and checks if their y is lower than the eat point (-5.11)
        // and then run Eat() [~ln 31]
        foreach(GameObject cal in GameObject.FindGameObjectsWithTag("eatable"))
        {
            if(cal.GetComponent<Transform>().position.y <= -5.11f)
            {
                Eat(cal);
            }
        }
    }

    void Eat(GameObject obj)
    {
        // add the calories to hole size & grow the hole [HoleManager, ~ln 66]
        hm.holeSize += obj.GetComponent<Eatable>().calories;
        hm.Grow();

        //check if it can be launched, and set the gameobject to false if it can;
        if (obj.GetComponent<Eatable>().launchable)
        {
            // if the object is launchable, it adds it to the insidehole list, sets the parent to the hole,
            //then makes the local position centered on the hole and above the eat pt and deactivates it.
            hm.insideHole.Add(obj);
            obj.GetComponent<Transform>().position = new Vector3(0, -5.5f, 0);
            obj.layer = 9;
            obj.SetActive(false);
        }
        else
        {
            // if the object isnt launchable, just destroy it
            Destroy(obj);
        }
    }
}

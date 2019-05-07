﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float camSpeed;

    public bool triggerOne, triggerTwo, triggerThree, triggerFour;

    public Vector3[] waypoints;
    public Vector3[] rotations;

    private void Awake()
    {
        transform.position = waypoints[0];
        transform.rotation = Quaternion.Euler(rotations[0]);
    }

    private void Update()
    {
        if(triggerOne)
        {
            MoveCam(waypoints[1], rotations[1]);
            Debug.Log("SHIFT TO ONE");
        }
        else if (triggerTwo)
        {
            MoveCam(waypoints[2], rotations[2]);
        }
        else if (triggerThree)
        {
            MoveCam(waypoints[3], rotations[3]);
        }
        else if(triggerFour)
        {
            MoveCam(waypoints[4], rotations[4]);
        }
    }

    void MoveCam(Vector3 newPos, Vector3 newRot)
    {
        transform.position = Vector3.Lerp(transform.position, newPos,camSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRot), Time.deltaTime * camSpeed);
    }
}

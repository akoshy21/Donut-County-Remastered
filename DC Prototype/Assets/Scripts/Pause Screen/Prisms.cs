using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisms : MonoBehaviour
{
    private Transform myT;
    public float speed, speed1, speed2;
    
    void Start()
    {
        myT = GetComponent<Transform>();

        //speed for each prism is random btw speed 1 & speed 2 
        speed = Random.Range(speed1, speed2);
    }
    
    void Update()
    {
        myT.Rotate(new Vector3((speed * Time.deltaTime), (speed * Time.deltaTime), (speed * Time.deltaTime)));
    }
}

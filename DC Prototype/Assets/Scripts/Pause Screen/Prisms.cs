using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisms : MonoBehaviour
{
    private Transform myT;
    public float speed, speed1, speed2;

    // Start is called before the first frame update
    void Start()
    {
        myT = GetComponent<Transform>();
        speed = Random.Range(speed1, speed2);
    }

    // Update is called once per frame
    void Update()
    {
        myT.Rotate(new Vector3((speed * Time.deltaTime), (speed * Time.deltaTime), (speed * Time.deltaTime)));
    }
}

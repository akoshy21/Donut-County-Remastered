using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumballTrigger : MonoBehaviour
{
    public float rotationStep;
    public bool hit;
    public GameObject balloon;
    public float rotationAmount;
    public GameObject spinner;

    void Update()
    {
        if (rotationAmount >= rotationStep)
        {
            spinner.transform.Rotate(0, 0, rotationStep * Time.deltaTime);
            rotationAmount -= rotationStep;
        }
    }

    public void SpinAndDispense()
    {
        rotationAmount += 4000;
        Instantiate(balloon);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT " + other.gameObject.name);
        SpinAndDispense();
    }

    private void onCollisionEnter(Collider other)
    {
        Debug.Log("HIT " + other.gameObject.name);
        SpinAndDispense();
    }
}

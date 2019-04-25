using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumballTrigger : MonoBehaviour
{
    public float rotationStep;
    public bool hit;
    public GameObject balloon;
    public float rotationAmount;

    void Update()
    {
        if (rotationAmount >= rotationStep)
        {
            this.transform.Rotate(0, 0, rotationStep * Time.deltaTime);
            rotationAmount -= rotationStep;
        }
    }

    public void SpinAndDispense()
    {
        rotationAmount += 400;
        Instantiate(balloon);
    }

    private void onCollisionEnter(Collider other)
    {
            Debug.Log("HIT " + other.gameObject.name);
            SpinAndDispense();
    }
}

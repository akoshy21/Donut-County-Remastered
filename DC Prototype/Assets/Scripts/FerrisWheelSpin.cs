using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheelSpin : MonoBehaviour
{
    public int count = 0;
    public float rotationAmount, rotationStep;
    public bool crashed = false;
    bool spinUp = false;

    private void Update()
    {
        if (!crashed)
        {
            this.transform.Rotate(0, 0, rotationStep * Time.deltaTime);
        }
    }

    public void Spin(int num)
    {
        if (num > 1)
        {
            rotationStep += 1;
        }
        else {
            rotationStep += 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("water"))
        {
            Spin(count);
            count++;
        }
    }
}

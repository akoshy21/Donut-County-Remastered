using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheelSpin : MonoBehaviour
{
    public int count = 0;
    public float rotationAmount, rotationStep;

    private void Update()
    {
        if (rotationAmount >= rotationStep)
        {
            this.transform.Rotate(0, 0, rotationStep * Time.deltaTime);
            rotationAmount -= rotationStep * Time.deltaTime;
        }
    }

    public void Spin(int num)
    {
        if (num > 1)
        {
            rotationAmount += 160;
            rotationStep = 60;
        }
        else {
            rotationAmount += 80;
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

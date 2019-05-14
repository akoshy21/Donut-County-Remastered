using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheelSpin : MonoBehaviour
{
    public int count = 0;
<<<<<<< HEAD
    public float rotationAmount, rotationStep;

    public GameObject cam;
=======
    public float rotationAmount, rotationStep;
    public bool crashed = false;
    bool spinUp = false;
>>>>>>> 721b5b4ce77361d0f011a02f3188c24d40c5fa91

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
<<<<<<< HEAD
        {
            rotationAmount += 160;
            rotationStep = 60;
            cam.GetComponent<CameraMover>().selectedWP++;
=======
        {
            rotationStep += 1;
>>>>>>> 721b5b4ce77361d0f011a02f3188c24d40c5fa91
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

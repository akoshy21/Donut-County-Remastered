using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumballTrigger : MonoBehaviour
{
    public float rotationStep;
    public bool hit;
    public GameObject balloonG, balloonP, balloonB;
    public GameObject spinner;
    public float rotationAmount;
    GameObject lastHit;


    void Update()
    {
        if (rotationAmount >= rotationStep)
        {
            spinner.transform.Rotate(0, 0, rotationStep * Time.deltaTime);
            rotationAmount -= rotationStep * Time.deltaTime;
        }
    }

    public void SpinAndDispense()
    {
        rotationAmount += 80;
        int rand = Random.Range(1, 100);

        if(rand <= 33)
        {
            Instantiate(balloonG);
        }
        else if (rand > 33 && rand < 67)
        {
            Instantiate(balloonP);
        }
        else if (rand >= 67)
        {
            Instantiate(balloonB);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!hit)
        {
            if (col.gameObject.tag.Equals("eatable"))
            {
                if (col.GetComponent<Eatable>().launchable)
                {
                    hit = true;
                    SpinAndDispense();
                    Debug.Log("UH. STUFF");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform.position.y < 0.63)
        {
            hit = false;
        }
    }
}

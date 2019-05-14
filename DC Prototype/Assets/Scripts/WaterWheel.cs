﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWheel : MonoBehaviour
{
    public bool hit;
    public Vector3[] nextPos, nextRot;
    public float speed;
    public int ind = 0;

    public GameObject gumball, gumballNoGo, waterPuddle;

    public GameObject logBoy;
    public bool move;
    public bool goOn;

    public GameObject maincam;
    public float rotationAmount, rotationStep;

    private void OnTriggerEnter(Collider col)
    {
        if (!hit)
        {
            if (col.gameObject.tag.Equals("water"))
            {
                move = true;
                ind++;
                Debug.Log("WATERRRRR. " + ind);
                hit = true;
                Spin();
            }
        }
    }

    private void Update()
    {
        if (hit)
        {
            StartCoroutine(Wait());
        }

        if (move)
        {
            MoveThatCoon();

        }
        if(ind == 1)
        {
            maincam.GetComponent<CameraMover>().selectedWP = 4;
        }

        if (rotationAmount >= rotationStep)
        {
            this.transform.Rotate(0, 0, rotationStep * Time.deltaTime);
            rotationAmount -= rotationStep * Time.deltaTime;
        }
    }

    private void Start()
    {
        logBoy.transform.position = nextPos[0];
        logBoy.transform.rotation = Quaternion.Euler(nextRot[0]);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        hit = false;
    }

    void MoveThatCoon() {
        if (ind < 3)
        {
            logBoy.transform.position = Vector3.Lerp(logBoy.transform.position, nextPos[ind], speed * Time.deltaTime);
            logBoy.transform.rotation = Quaternion.Lerp(logBoy.transform.rotation, Quaternion.Euler(nextRot[ind]), Time.deltaTime * speed);
        }
        else if(ind >= 3 && ind < 10)
        {
            logBoy.transform.position = Vector3.Lerp(logBoy.transform.position, nextPos[ind], speed * Time.deltaTime);
            logBoy.transform.rotation = Quaternion.Lerp(logBoy.transform.rotation, Quaternion.Euler(nextRot[ind]), Time.deltaTime * speed);

            if (Vector3.Distance(logBoy.transform.position, nextPos[ind]) <= 0.25f)
            {
                ind++;
            }
        }
        else if(ind == 10)
        {
            if (goOn)
            {
                logBoy.transform.position = Vector3.Lerp(logBoy.transform.position, nextPos[ind], speed * Time.deltaTime);
                logBoy.transform.rotation = Quaternion.Lerp(logBoy.transform.rotation, Quaternion.Euler(nextRot[ind]), Time.deltaTime * speed);
            }
            if (Vector3.Distance(logBoy.transform.position, nextPos[ind]) <= 0.25f)
            {
                logBoy.GetComponent<Rigidbody>().isKinematic = false;
                gumball.GetComponent<Rigidbody>().isKinematic = false;
                waterPuddle.gameObject.SetActive(true);
                gumballNoGo.SetActive(false);
                gumball.transform.Translate(0, 0.1f, 0);
                goOn = false;
            }
        }
    }

    public void Spin()
    {
        rotationAmount += 80;
        int rand = Random.Range(1, 100);
    }
}

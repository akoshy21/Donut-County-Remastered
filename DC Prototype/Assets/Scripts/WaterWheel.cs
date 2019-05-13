using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWheel : MonoBehaviour
{
    public bool hit;
    public Vector3[] nextPos, nextRot;
    public float speed;
    public int ind = 0;

    public GameObject logBoy;
    public bool move;

    public GameObject maincam;

    private void OnTriggerEnter(Collider col)
    {
        if (!hit)
        {
            if (col.gameObject.tag.Equals("water"))
            {
                move = true;
                ind++;
                Debug.Log("WATERRRRR.");
                hit = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("water"))
        {
            hit = false;
        }
    }

    private void Update()
    {
        if(move)
        {
            MoveThatCoon();

        }
        if(ind == 1)
        {
            maincam.GetComponent<CameraMover>().selectedWP = 5;
        }
    }

    private void Start()
    {
        logBoy.transform.position = nextPos[0];
        logBoy.transform.rotation = Quaternion.Euler(nextRot[0]);
    }

    void MoveThatCoon() {
        if (ind < nextPos.Length)
        {
            logBoy.transform.position = Vector3.Lerp(logBoy.transform.position, nextPos[ind], speed * Time.deltaTime);
            logBoy.transform.rotation = Quaternion.Lerp(logBoy.transform.rotation, Quaternion.Euler(nextRot[ind]), Time.deltaTime * speed);
        }
        else {
            logBoy.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}

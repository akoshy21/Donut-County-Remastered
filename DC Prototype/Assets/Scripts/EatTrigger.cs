using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatTrigger : MonoBehaviour
{
    public GameObject manager;
    public HoleManager man;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
        man = manager.GetComponent<HoleManager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "eatable")
        {
            man.insideHole.Add(col.gameObject);
            man.holeSize += col.gameObject.GetComponent<Eatable>().calories;
            man.Grow();
        }
    }
}

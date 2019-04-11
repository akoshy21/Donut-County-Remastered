using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public HoleManager manager;
    public float launchForce;

    void Start()
    {
        manager = GetComponent<HoleManager>();   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Liftoff();
        }
    }
    
    private void Liftoff()
    {
        for (int i = manager.insideHole.Count - 1; i >= 0; i--)
        {
            GameObject current = manager.insideHole[i];
            if (current.GetComponent<Eatable>().launchable)
            {
                current.gameObject.SetActive(true);
                current.transform.parent = null;
                current.transform.rotation = Quaternion.Euler(0, 0, 0);
                current.GetComponent<Rigidbody>().velocity = Vector3.zero;
                current.GetComponent<Rigidbody>().AddForce(Vector3.up * launchForce, ForceMode.Impulse);
                manager.insideHole.Remove(current);
                manager.Shrink();
                manager.holeSize -= current.GetComponent<Eatable>().calories;
                break;
            }
        }
    }
}

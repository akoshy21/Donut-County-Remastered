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
                //turn the game object back on
                current.gameObject.SetActive(true);

                //set its position and rotation to a resting state
                current.transform.parent = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                current.transform.rotation = Quaternion.Euler(0, 0, 0);
                current.GetComponent<Rigidbody>().velocity = Vector3.zero;

                //yeet that bitch
                current.GetComponent<Rigidbody>().AddForce(Vector3.up * launchForce, ForceMode.Impulse);

                //change the hole accordingly
                manager.insideHole.Remove(current);
                manager.Shrink();
                manager.holeSize -= current.GetComponent<Eatable>().calories;

                break;
            }
        }
    }
}

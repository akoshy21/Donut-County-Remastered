using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public HoleManager manager;
    public float launchForce;
    public GameObject waterCyl;
    public bool waterSpray;

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

        if(waterSpray == true)
        {
            StartCoroutine(Water());        
        }
    }
    
    private void Liftoff()
    {
        for (int i = manager.insideHole.Count - 1; i >= 0; i--)
        {
            GameObject current = manager.insideHole[i];
            if (current.GetComponent<Eatable>().launchable)
            {
                if (current.tag.Equals("water"))
                {
                    waterSpray = true;
                    manager.insideHole.Remove(current);
                }
                else
                {
                    LaunchObject(current);
                    current.layer = 9;
                }
                break;
            }
        }
    }

    void LaunchObject(GameObject obj)
    {
        // turn the game object back on
        obj.gameObject.SetActive(true);

        //set its position and rotation to a resting state
        obj.transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
        obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;

        //yeet that bitch
        obj.GetComponent<Rigidbody>().AddForce(Vector3.up * launchForce, ForceMode.Impulse);

        //change the hole accordingly
        manager.insideHole.Remove(obj);
        manager.Shrink();
        manager.holeSize -= obj.GetComponent<Eatable>().calories;
    }

    public IEnumerator Water()
    {
        waterCyl.SetActive(true);
        yield return new WaitForSeconds(3);
        waterCyl.SetActive(false);
        waterSpray = false;
    }
}

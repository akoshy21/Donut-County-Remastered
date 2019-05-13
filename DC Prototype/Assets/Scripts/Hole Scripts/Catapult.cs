using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public HoleManager manager;
    public float launchForce;
    public GameObject waterCyl;
    public bool waterSpray;
    public GameObject CatapultModel;

    void Start()
    {
        CatapultModel.GetComponent<Animator>().enabled = false;
        manager = GetComponent<HoleManager>();  // set manager to HoleManager component
    }

    void Update()
    {
        // on click, liftoff
        if (Input.GetMouseButtonDown(0))
        {
            Liftoff();
        }
        if(manager.insideHole.Count > 0)
        {
            CatapultModel.SetActive(true);
        }

        // if waterspray is true, then start the water coroutine [~ ln 76]
        if (waterSpray == true)
        {
            Debug.Log("SPRAY");
            StartCoroutine(Water());
            waterSpray = false;
            manager.waterFill = false;
        }
    }
    
    private void Liftoff()
    {
        
        // get the last object in the hole.
        for (int i = manager.insideHole.Count - 1; i >= 0; i--)
        {
            // the current object is that object at the last index (ie. index of i)
            GameObject current = manager.insideHole[i];

            // check if object is eatable & launchable or water
            if (current.GetComponent<Eatable>() != null && current.GetComponent<Eatable>().launchable)
            {
                CatapultModel.GetComponent<Animator>().enabled = true;
                CatapultModel.GetComponent<Animator>().Play(0);
                //CatapultModel.GetComponent<Animator>().
                // launch object, and set the objects layer to above; [~ln 60]
                LaunchObject(current);
                current.layer = 9;

            }
            else if(current.tag.Equals("water"))
            {
                if (manager.insideHole.Count <= 0)
                {
                    CatapultModel.SetActive(false);
                }

                // set waterspray to true, remove the last entry in hole
                waterSpray = true;
                manager.insideHole.Remove(current);
            }
            break;
        }
    }

    void LaunchObject(GameObject obj)
    {
        // turn the game object back on
        obj.gameObject.SetActive(true);
        // set its magnetic quality back to true when it exits
        obj.GetComponent<Eatable>().magnetic = true;

        //set its position and rotation to a resting state
        obj.transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
        obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;

        //launch the object
        obj.GetComponent<Rigidbody>().AddForce(Vector3.up * launchForce, ForceMode.Impulse);

        //change the hole accordingly
        manager.insideHole.Remove(obj);
        manager.Shrink();
        manager.holeSize -= obj.GetComponent<Eatable>().calories;
    }

    public IEnumerator Water()
    {
        // set the water cylinder to active, wait 3 seconds, then de-activate
        // the water cylinder & set the waterfill to false
        waterCyl.SetActive(true);
        waterCyl.GetComponentInChildren<ParticleSystem>().Emit(40);
        yield return new WaitForSeconds(3);
        waterCyl.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public float speedMod;
    public float holeSize = 1;
    public List<GameObject> insideHole = new List<GameObject>();
    public Vector3 origPos;
    public bool waterFill;
    public GameObject water;
    public Camera cam;

    public AudioClip pop;


    // Update is called once per frame
    void Update()
    {
        // send out a ray to check where the mouse is and move the hole toward that point based on the speed mod
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Default layer ensures that only the floor impacts our hole position
        if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Default")))
        {
            Vector3 objectHit = new Vector3(hit.point.x,-0.12f,hit.point.z);
            objectHit.y = this.transform.position.y; // y is preset by us.

            transform.position = Vector3.MoveTowards(this.transform.position, objectHit, speedMod);
        }

        // if waterFill is true, then have the water object in the hole set to true.
        if(waterFill)
        {
            water.SetActive(true);
        }
        else if (!waterFill)
        {
            water.SetActive(false);
        }

        // coroutine UpdateCol runs [~ ln 68]
        StartCoroutine(UpdateCol());
    }

    public void Grow()
    {
        // scales the hole to the holeSize
        Vector3 modSize = new Vector3(holeSize,0,holeSize);

        transform.localScale += modSize * 0.01f;

        // play the grow sound effect
        this.GetComponent<AudioSource>().clip = pop;
        this.GetComponent<AudioSource>().Play();
    }

    public IEnumerator UpdateCol()
    {
        // wait a second, then for every collider in the physics sphere that's eatable
        // disable and enable the collider
        // used as a bug fix to the issue of objects not changing layers upon slowly entering the hole.
        yield return new WaitForSeconds(1);
        foreach (Collider col in Physics.OverlapSphere(transform.position, this.transform.localScale.x / 2.1f))
        {if (col.gameObject.tag.Equals("eatable"))
            {
            col.enabled = false;
            col.enabled = true;
            }
        }
    }

    public void Shrink()
    {
        // scales the hole to the holeSize
        Vector3 modSize = new Vector3(holeSize, 0, holeSize);

        transform.localScale -= modSize * 0.01f;

        // PUT SHRINK SOUND EFFECT HERE

    }
}

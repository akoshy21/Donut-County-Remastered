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
    public GameObject holeLead;

    public AudioClip pop;


    private Vector3 change;


    // Update is called once per frame
    void Update()
    {
        for (int i = insideHole.Count - 1; i >= 0; i--)
        {
            if(i < insideHole.Count-1)
            {
                insideHole[i].SetActive(false);
            }
            else if(!(insideHole[i].tag == "water"))
            {
                insideHole[i].SetActive(true);
            }
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

    private void LateUpdate()
    {
        transform.position = holeLead.transform.position;
        //float dist = Vector3.Distance(holeLead.transform.position, this.transform.position);

        //if (Mathf.Abs(dist) > 0.08f)
        //{
        //    transform.position = Vector3.MoveTowards(this.transform.position, holeLead.transform.position, 80f * Time.deltaTime);
        //}
        //else if (Mathf.Abs(dist) > 0.03f)
        //{
        //    transform.position = Vector3.MoveTowards(this.transform.position, holeLead.transform.position, 13f * Time.deltaTime);
        //}
        //else if (Mathf.Abs(dist) > 0.01f)
        //{
        //    transform.position = Vector3.MoveTowards(this.transform.position, holeLead.transform.position, 1f * Time.deltaTime);
        //}
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

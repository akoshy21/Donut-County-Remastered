using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketManager : MonoBehaviour
{
    public GameObject hole;
    public Image circle;
    public GameObject refModel = null;

    public static PocketManager pm;

    private void Awake()
    {
        if (pm != null && pm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            pm = this;
        }
    }

    private void Update()
    {
        CheckPocket();

        if(refModel != null)
        {
            refModel.transform.Rotate(0, 50 * Time.deltaTime, 0);
        }
    }

    void CheckPocket()
    {
        if(hole.GetComponent<HoleManager>().insideHole.Count > 0)
        {
            circle.gameObject.SetActive(true);
        }
        else {
            circle.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pocket : MonoBehaviour
{
    public GameObject hole;
    public Image circle;
    GameObject refModel = null;
    public float h, w;

    // Start is called before the first frame update
    void Start()
    {
        h = Camera.main.orthographicSize * 2;
        w = h * Screen.width / Screen.height; 
    }

    // Update is called once per frame
    void Update()
    {
        CheckPocket();
        if(refModel !=null)
        {
            refModel.transform.Rotate(0, 50 * Time.deltaTime, 0);
}
    }

    void CheckPocket()
    {
        if(hole.GetComponent<HoleManager>().insideHole.Count > 0)
        {
            circle.gameObject.SetActive(true);
            if (refModel != null && !refModel.name.Equals(hole.GetComponent<HoleManager>().insideHole[hole.GetComponent<HoleManager>().insideHole.Count - 1].name))
            {
                Destroy(refModel.gameObject); 
            }
            refModel = Instantiate(hole.GetComponent<HoleManager>().insideHole[hole.GetComponent<HoleManager>().insideHole.Count - 1], circle.transform);
                    
        }
        else {
            circle.gameObject.SetActive(false);
            }
    }
}

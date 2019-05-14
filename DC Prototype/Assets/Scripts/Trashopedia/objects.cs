using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objects : MonoBehaviour
{
    public GameObject Mpos;

    RectTransform myRect;

    Transform myT;

    // Start is called before the first frame update
    void Start()
    {
        myT = GetComponent<Transform>();
        myRect = Mpos.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        myT.position.x.Equals(myRect.position.x);
        myT.position.y.Equals(myRect.position.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingCircles : MonoBehaviour
{
    public Button right1;
    public Button right2;
    public Button left1;
    public Button left2;

    public List<Vector3> pos = new List<Vector3>();
    public List<GameObject> objs = new List<GameObject>();

    void Start()
    {
        int j = 0;

        for(int i = 6; i < 20; i++)
        {   
            Debug.Log("obj" + j + "is at pos" + i);
            objs[j].GetComponent<RectTransform>().anchoredPosition = pos[i];
            j++;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RightArrow();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftArrow();
        }
    }

    void RightArrow()
    {

    }

    void LeftArrow()
    {

    }
}

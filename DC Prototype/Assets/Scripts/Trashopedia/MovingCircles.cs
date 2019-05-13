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

    private int first = 9;

    void Start()
    {
        int j = 0;

        for(int i  = first; i < 20; i++)
        {   
            Debug.Log("obj" + j + "is at pos" + first);
            objs[j].GetComponent<RectTransform>().anchoredPosition = pos[i];
            j++;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
                RightArrow();     
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftArrow();
        }
    }

    void RightArrow()
    {
        int j = 0;
        first++;

        for (int i = first; i < 20; i++)
        {
            Debug.Log("obj" + j + "is at pos" + first);
            objs[j].GetComponent<RectTransform>().anchoredPosition = pos[i];
            j++;
        }

        return;
    }

    void LeftArrow()
    {
        int j = 0;
        first--;

        for (int i = first; i < 20; i++)
        {
            Debug.Log("obj" + j + "is at pos" + first);
            objs[j].GetComponent<RectTransform>().anchoredPosition = pos[i];
            j++;
        }

        return;
    }
}

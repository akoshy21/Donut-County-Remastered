using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingCircles : MonoBehaviour
{
    public Text objName;
    public Text objDesc;

    public int speed;

    public Button right1;
    public Button right2;
    public Button left1;
    public Button left2;

    public List<Vector3> pos = new List<Vector3>();
    public List<GameObject> objs = new List<GameObject>();

    public Texture mainImg;
    public Texture bgImg;

    public int first;
    private int textnum = 0;

    private List<string> names = new List<string>();
    private List<string> descs = new List<string>();

    void Start()
    {
        int j = 0;

        for(int i  = first; i < 20; i++)
        {   
            //Debug.Log("obj" + j + "is at pos" + first);
            objs[j].GetComponent<RectTransform>().anchoredPosition = pos[i];
            j++;
        }

        objName.GetComponent<Text>();
        objDesc.GetComponent<Text>();

        names.Add(Trashlist.instance.n0);
        names.Add(Trashlist.instance.n1);
        names.Add(Trashlist.instance.n2);
        names.Add(Trashlist.instance.n3);
        names.Add(Trashlist.instance.n4);
        names.Add(Trashlist.instance.n5);
        names.Add(Trashlist.instance.n6);
        names.Add(Trashlist.instance.n7);

        descs.Add(Trashlist.instance.d0);
        descs.Add(Trashlist.instance.d1);
        descs.Add(Trashlist.instance.d2);
        descs.Add(Trashlist.instance.d3);
        descs.Add(Trashlist.instance.d4);
        descs.Add(Trashlist.instance.d5);
        descs.Add(Trashlist.instance.d6);
        descs.Add(Trashlist.instance.d7);

        objName.text = names[textnum];
        objDesc.text = descs[textnum];

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

        for (int i = 0; i < 7; i++) {

            if (objs[i].GetComponent<RectTransform>().anchoredPosition.Equals(pos[10]))
            {
                objs[i].GetComponent<RawImage>().texture = mainImg;
                
                objs[i].GetComponent<RectTransform>().localScale = Vector3.Lerp(new Vector3(1.7f, 1.7f, 1.7f), new Vector3(.7f, .7f, .7f), speed * Time.deltaTime);

            }
            else
            {
                objs[i].GetComponent<RawImage>().texture = bgImg;
                
                // objs[i].GetComponent<RectTransform>().localScale = new Vector3(.6f, .6f, .6f);
                objs[i].GetComponent<RectTransform>().localScale = Vector3.Lerp(new Vector3(.7f, .7f, .7f), new Vector3(1.7f, 1.7f, 1.7f), speed * Time.deltaTime);
            }
        }
    }

    void RightArrow()
    {
        int j = 0;
        first++;

        for (int i = first; i < 20; i++)
        {
            //Debug.Log("obj" + j + "is at pos" + first);
            objs[j].GetComponent<RectTransform>().anchoredPosition = pos[i];
            //this is supposed to lerp but like i cry 
            //objs[j].GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(objs[j].GetComponent<RectTransform>().anchoredPosition, pos[i], speed, Time.deltaTime);
            j++;
        }

        /*if (textnum < 7)
        {
            objName.text = names[textnum + 1];
            objDesc.text = descs[textnum + 1];
        }*/

        return;
    }

    void LeftArrow()
    {
        int j = 0;
        first--;

        for (int i = first; i < 20; i++)
        {
            //Debug.Log("obj" + j + "is at pos" + first);
            objs[j].GetComponent<RectTransform>().anchoredPosition = pos[i];
            j++;
        }

        /*if (textnum > 0)
        {
            objName.text = names[textnum - 1];
            objDesc.text = descs[textnum - 1];
        }*/

        return;
    }
}

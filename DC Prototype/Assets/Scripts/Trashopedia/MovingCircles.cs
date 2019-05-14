using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingCircles : MonoBehaviour
{

    public int speed;

    public Button right1;
    public Button right2;
    public Button left1;
    public Button left2;

    public List<Vector3> pos = new List<Vector3>();
    public List<GameObject> objs = new List<GameObject>();
    public List<RawImage> imgs = new List<RawImage>();

    public Texture mainImg;
    public Texture bgImg;

    public int first;
    //private int textnum = 0;

    private List<string> names = new List<string>();
    private List<string> descs = new List<string>();

    public Color bgColor;
    public Color mainColor;

    void Start()
    {
        int j = first;

        for(int i  = 0; i < objs.Count; i++)
        {
            if (j >= 0 && j <= pos.Count)
            {
                Debug.Log("obj" + j + "is at pos" + first);
                objs[i].GetComponent<RectTransform>().anchoredPosition = pos[j];
                j++;
            }
        }

        //objName.GetComponent<Text>().text = names[textnum];
        //objDesc.GetComponent<Text>().text = descs[textnum];

        right1.onClick.AddListener(RightArrow);
        left1.onClick.AddListener(LeftArrow);

        right2.onClick.AddListener(RightArrow);
        left2.onClick.AddListener(LeftArrow);

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

                imgs[i].color.Equals(bgColor);

            }
            else
            {
                objs[i].GetComponent<RawImage>().texture = bgImg;
                
                // objs[i].GetComponent<RectTransform>().localScale = new Vector3(.6f, .6f, .6f);
                objs[i].GetComponent<RectTransform>().localScale = Vector3.Lerp(new Vector3(.7f, .7f, .7f), new Vector3(1.7f, 1.7f, 1.7f), speed * Time.deltaTime);

                imgs[i].color.Equals(mainColor);
            }
        }
    }

    void RightArrow()
    {
        first--;
        int j = first;

        for (int i = 0; i < objs.Count; i++)
        {
            if (j >= 0 && j <= pos.Count)
            {
                //Debug.Log("obj" + j + "is at pos" + first);
                objs[i].GetComponent<RectTransform>().anchoredPosition = pos[j];
                //this is supposed to lerp but like i cry 
                //objs[j].GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(objs[j].GetComponent<RectTransform>().anchoredPosition, pos[i], speed, Time.deltaTime);
                j++;
            }
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
        first++;
        int j = first;

        for (int i = 0; i < objs.Count; i++)
        {
            if (j >= 0 && j <= pos.Count)
            {
                //Debug.Log("obj" + j + "is at pos" + first);
                objs[i].GetComponent<RectTransform>().anchoredPosition = pos[j];
                j++;
            }
        }

        /*if (textnum > 0)
        {
            objName.text = names[textnum - 1];
            objDesc.text = descs[textnum - 1];
        }*/

        return;
    }
}

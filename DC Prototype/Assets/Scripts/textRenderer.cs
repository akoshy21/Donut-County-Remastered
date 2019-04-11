using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue
{
    public string text;
    public int currentChar;

    public Dialogue(string Text, int CurrentChar)
    {
        text = Text;
        currentChar = CurrentChar;
    }
}

public class textRenderer : MonoBehaviour
{
    public List<Dialogue> dialogue = new List<Dialogue>();

    public Camera myCam;

    public Vector3 miraPos;
    public Vector3 miraRot;
    public Vector3 bkPos;
    public Vector3 bkRot;

    private int mira = 0;
    private int bk = 1;

    public Text txt;
    public int idx;

    public float speed;

    Dialogue d1;
    Dialogue d2;
    Dialogue d3;
    Dialogue d4;

    void Start()
    {
        d1 = new Dialogue(CutsceneScript.instance.l1, mira);
        d2 = new Dialogue(CutsceneScript.instance.l2, bk);
        d3 = new Dialogue(CutsceneScript.instance.l3, bk);
        d4 = new Dialogue(CutsceneScript.instance.l4, mira);

        dialogue.Add(d1);
        dialogue.Add(d2);
        dialogue.Add(d3);
        dialogue.Add(d4);

        idx = 0;
        txt.text = dialogue[idx].text;

        myCam.transform.position = miraPos;
        myCam.transform.rotation = Quaternion.Euler(miraRot);
    }

    void Update()
    {
        //text progresses with spacebar
        txt.text = dialogue[idx].text;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            idx++;
        }

        //camera changes to character speaking 
        if (dialogue[idx].currentChar == mira && idx > 0)
        {
            if (dialogue[idx - 1].currentChar != mira)
            {
                myCam.transform.position = Vector3.Lerp(myCam.transform.position, miraPos, .5f);
                myCam.transform.rotation = Quaternion.Euler(miraRot);
            }
        }
        else if (dialogue[idx].currentChar == bk && idx > 0)
        {
            if (dialogue[idx - 1].currentChar != bk)
            {
                myCam.transform.position = Vector3.Lerp(myCam.transform.position, bkPos, .5f); ;
                myCam.transform.rotation = Quaternion.Euler(bkRot);
            }
        }
    }
}

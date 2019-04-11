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
    public Vector3 bkPos;

    private int mira = 0;
    private int bk = 1;

    public Text txt;
    private int idx;

    Dialogue d1;
    Dialogue d2;

    void Start()
    {
        d1 = new Dialogue(CutsceneScript.instance.l1, mira);
        d2 = new Dialogue(CutsceneScript.instance.l2, bk);

        dialogue.Add(d1);
        dialogue.Add(d2);

        idx = 0;
        txt.text = dialogue[idx].text;

        miraPos = new Vector3(0, 0, 0);
        bkPos = new Vector3(0, 0, 0);
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
                myCam.transform.position = miraPos;
            }
        }
        else if (dialogue[idx].currentChar == bk && idx > 0)
        {
            if (dialogue[idx - 1].currentChar != bk)
            {
                myCam.transform.position = bkPos;
            }
        }
    }
}

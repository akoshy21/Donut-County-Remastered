using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public RawImage miraTB;
    public RawImage bkTB;

    public Text txt;
    public Text nametag;
    public int idx;

    public float speed;

    Dialogue d1;
    Dialogue d2;
    Dialogue d3;
    Dialogue d4;

    private int length;

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

        length = 4;

        idx = 0;
        txt.text = dialogue[idx].text;

        myCam.transform.position = miraPos;
        myCam.transform.rotation = Quaternion.Euler(miraRot);
    }

    void Update()
    {
        //text progresses with spacebar
        txt.text = dialogue[idx].text;

        if(dialogue[idx].currentChar == mira)
        {
            nametag.text = "mira";
            miraTB.enabled = true;
            bkTB.enabled = false;

        }else if(dialogue[idx].currentChar == bk)
        {
            nametag.text = "bk";
            bkTB.enabled = true;
            miraTB.enabled = false;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (idx < length - 1)
            {
                idx++;
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        //camera changes to character speaking 
        if (dialogue[idx].currentChar == mira && idx > 0)
        {
            if (dialogue[idx - 1].currentChar != mira)
            {
                myCam.transform.position = Vector3.Lerp(myCam.transform.position, miraPos, speed * Time.deltaTime);
                myCam.transform.rotation = Quaternion.Lerp(myCam.transform.rotation, Quaternion.Euler(miraRot), Time.time * speed);
            }
        }
        else if (dialogue[idx].currentChar == bk && idx > 0)
        {
            if (dialogue[idx - 1].currentChar != bk)
            {
                myCam.transform.position = Vector3.Lerp(myCam.transform.position, bkPos, speed * Time.deltaTime); ;
                myCam.transform.rotation = Quaternion.Lerp(myCam.transform.rotation, Quaternion.Euler(bkRot), Time.time * speed);
            }
        }
        }
    }

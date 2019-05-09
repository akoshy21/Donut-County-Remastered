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

    public Material miraMat;
    public Material bkMat;

    public Text txt;
    public Text nametag;
    public Text dots;
    public int idx;

    public GameObject fader;

    public bool complete;

    public float speed;

    Dialogue[] d;

    private int length;

    //text appears letter by letter
    IEnumerator AnimateText(string line)
    {
        int i = 0;
        string str = "";

        while( i < line.Length)
        {
            dots.enabled = false;
            str += line[i++];
            yield return new WaitForSeconds(0.05f);
            txt.text = str;
        }

        //if the line is complete show the "..."
        if(i >= line.Length)
        {
            complete = true;
            dots.enabled = true;
        }
    }

    void Start()
    {
        d = new Dialogue[18];
        //pulls dialogue from CutsceneScript & assigns character
        d[0] = new Dialogue(CutsceneScript.instance.l[0], mira);
        d[1] = new Dialogue(CutsceneScript.instance.l[1], bk);
        d[2] = new Dialogue(CutsceneScript.instance.l[2], mira);
        d[3] = new Dialogue(CutsceneScript.instance.l[3], bk);
        d[4] = new Dialogue(CutsceneScript.instance.l[4], mira);
        d[5] = new Dialogue(CutsceneScript.instance.l[5], mira);
        d[6] = new Dialogue(CutsceneScript.instance.l[6], mira);
        d[7] = new Dialogue(CutsceneScript.instance.l[7], bk);
        d[8] = new Dialogue(CutsceneScript.instance.l[8], bk);
        d[9] = new Dialogue(CutsceneScript.instance.l[9], mira);
        d[10] = new Dialogue(CutsceneScript.instance.l[10], bk);
        d[11] = new Dialogue(CutsceneScript.instance.l[11], bk);
        d[12] = new Dialogue(CutsceneScript.instance.l[12], bk);
        d[13] = new Dialogue(CutsceneScript.instance.l[13], bk);
        d[14] = new Dialogue(CutsceneScript.instance.l[14], mira);
        d[15] = new Dialogue(CutsceneScript.instance.l[15], mira);
        d[16] = new Dialogue(CutsceneScript.instance.l[16], bk);
        d[17] = new Dialogue(CutsceneScript.instance.l[17], bk);

        //adds each line to dialogue list
        foreach (Dialogue di in d)
        {
            dialogue.Add(di); 
        }

        //num of lines in dialogue
        length = 18;
        idx = 0;

        //txt.text = dialogue[idx].text;
        StartCoroutine(AnimateText(dialogue[idx].text));

        myCam.transform.position = miraPos;
        myCam.transform.rotation = Quaternion.Euler(miraRot);
    }

    void Update()
    {
        //change name/textbox based on character
        if (dialogue[idx].currentChar == mira)
        {
            nametag.text = "Mira";
            txt.material = miraMat;
            miraTB.enabled = true;
            bkTB.enabled = false;

        } else if (dialogue[idx].currentChar == bk)
        {
            nametag.text = "BK";
            txt.material = bkMat;
            bkTB.enabled = true;
            miraTB.enabled = false;

        }

        //text progresses with spacebar
        //txt.text = dialogue[idx].text;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))&& complete == true)
        {
            //while there are still lines left in dialogue list
            if (idx < length - 1)
            {
                complete = false;
                idx++;
                StartCoroutine(AnimateText(dialogue[idx].text));
            }
            else
            {
                GameManager.manager.MainScene();
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

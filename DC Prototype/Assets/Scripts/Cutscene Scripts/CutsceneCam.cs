using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class CutsceneCam : MonoBehaviour
{
    public Camera myCam;

    public Vector3 miraPos;
    public Vector3 bkPos;

    public int index;
    private int mira;
    private int bk;

    // Start is called before the first frame update
    void Start()
    {
        CutsceneScript.instance.idx = index;
        CutsceneScript.instance.mira = mira;
        CutsceneScript.instance.bk = bk;

        miraPos = new Vector3(0, 0, 0);
        bkPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(CutsceneScript.instance.dialogue[index].currentChar == mira)
        {
            if (CutsceneScript.instance.dialogue[index - 1].currentChar != mira)
            {
                myCam.transform.position = miraPos;
            }
        } else if(CutsceneScript.instance.dialogue[index].currentChar == bk)
        {
            if (CutsceneScript.instance.dialogue[index - 1].currentChar != bk)
            {
                myCam.transform.position = bkPos;
            }
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCam : textRenderer
{
    public Camera myCam;

    public Vector3 miraPos;
    public Vector3 bkPos;

    // Start is called before the first frame update
    void Start()
    {
        miraPos = new Vector3(0, 0, 0);
        bkPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue[idx].currentChar == mira)
        {
            if (dialogue[idx - 1].currentChar != mira)
            {
                myCam.transform.position = miraPos;
            }
        } else if(dialogue[idx].currentChar == bk)
        {
            if (dialogue[idx - 1].currentChar != bk)
            {
                myCam.transform.position = bkPos;
            }
        }
    }
}

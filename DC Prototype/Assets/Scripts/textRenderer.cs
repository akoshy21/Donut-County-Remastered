using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textRenderer : CutsceneScript
{
    protected Text txt;
    protected int idx;

    // Start is called before the first frame update
    void Start()
    {
        idx = 0;
        txt.text = dialogue[idx].text;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = dialogue[idx].text;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            idx++;
        }
    }
}

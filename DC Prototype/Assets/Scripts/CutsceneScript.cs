using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public List<string> txts = new List<string>();

    public string txt1;
    public string txt2;



    // Start is called before the first frame update
    void Start()
    {
        txt1 = "hello";
        txts.Add(txt1);

        txt2 = "some more text";
        txts.Add(txt2);
    }

}

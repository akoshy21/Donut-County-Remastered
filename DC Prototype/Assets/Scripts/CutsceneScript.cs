using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : AnimatedText
{
    public static CutsceneScript instance;

    public string l1;
    public string l2;
    public string l3;
    public string l4;

    void Awake()
    {
        instance = this;

        l1 = "MIRA IS TALKING";

        l2 = "BK IS TALKING";

        l3 = "BK IS STILL TALKING";

        l4 = "MIRA IS TALKING AGAIN";
    }

}

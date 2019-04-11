using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public static CutsceneScript instance;

    public string l1;
    public string l2;
    public string l3;
    public string l4;

    void Awake()
    {
        instance = this;

        l1 = "mira is talking";

        l2 = "bk is talking";

        l3 = "bk is still talking";

        l4 = "mira is talking again";
    }

}

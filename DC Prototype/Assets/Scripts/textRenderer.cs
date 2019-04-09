using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textRenderer : MonoBehaviour
{

    public Text txt;

    private List<string> txts = new List<string>();
    private int idx = 0;

    private string txt1;
    private string txt2;

    // Start is called before the first frame update
    void Start()
    {
        txts.Add(txt1);
        txts.Add(txt2);

        txt.text = txts[idx];
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = txts[idx];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            idx++;
        }
    }
}

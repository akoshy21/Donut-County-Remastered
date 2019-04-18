using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedText : MonoBehaviour
{

    private Text txt;
    private string line;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        txt.text = line;

        for(int i = 0; i < line.Length; i++)
        {

        }
        
    }
}

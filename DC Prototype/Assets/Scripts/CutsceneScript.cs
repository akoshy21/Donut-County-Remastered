using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class CutsceneScript : MonoBehaviour
{
    public List<Dialogue> dialogue = new List<Dialogue>();

    protected int mira = 0;
    protected int bk = 1;

    public Dialogue d1;
    public Dialogue d2;



    // Start is called before the first frame update
    void Start()
    {
        d1 = new Dialogue("", mira);
        dialogue.Add(d1);

        d2 = new Dialogue("", bk);
        dialogue.Add(d2);
    }

}

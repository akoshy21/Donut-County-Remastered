using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Trashlist : MonoBehaviour
{
    // public static Trashlist instance;

    public MovingCircles circ;
    public Text objName;
    public Text objDesc;

    private List<string> names = new List<string>();
    private List<string> descs = new List<string>();

    private string n0 = "Fun Flume Log";
    private string d0 = "Ever think about all the other types of fumes besides log? I don't.";

    private string n1 = "Fun Flume";
    private string d1 = "What kind of monster would destroy the Fun Flume?";

    private string n2 = "Water Balloon";
    private string d2 = "Water balloons are like normal balloons filled with spite.";

    private string n3 = "Construction Cone";
    private string d3 = "Cone is an underutilised and frankly disrespected shape.";

    private string n4 = "Water Balloon Dispenser" ;
    private string d4 = "Water balloons help you complete the puzzle.";

    private string n5 = "Castle" ;
    private string d5 = "A princess house. Princesses make excellent garbage. ";

    private string n6 = "Circus Tent";
    private string d6 = "A very ugly dress for giants.";

    private string n7 = "Theme Park Trash Can";
    private string d7 = "A home for used corn dogs.";


    public int idx;

    public void Start()
    {
        idx = 10 - circ.first;
        names.Add(n0);
        names.Add(n1);
        names.Add(n2);
        names.Add(n3);
        names.Add(n4);
        names.Add(n5);
        names.Add(n6);
        //names.Add(n7);

        descs.Add(d0);
        descs.Add(d1);
        descs.Add(d2);
        descs.Add(d3);
        descs.Add(d4);
        descs.Add(d5);
        descs.Add(d6);
        //descs.Add(d7);

        objName.text = names[idx];
        objDesc.text = descs[idx];

        circ.right1.onClick.AddListener(moveRight);
        circ.left1.onClick.AddListener(moveLeft);

        circ.right2.onClick.AddListener(moveRight);
        circ.left2.onClick.AddListener(moveLeft);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft();
        }
    }

    void moveRight()
    {
        idx++;
        if (idx >= 0 && idx <= names.Count)
        {
            objName.text = names[idx];
            objDesc.text = descs[idx];
        }

        Debug.Log(idx);

        return;
    }

    void moveLeft()
    {
        idx--;
        if (idx >= 0 && idx <= names.Count)
        {
            objName.text = names[idx];
            objDesc.text = descs[idx];
        }
       // Debug.Log(idx);

        return;
    }
}

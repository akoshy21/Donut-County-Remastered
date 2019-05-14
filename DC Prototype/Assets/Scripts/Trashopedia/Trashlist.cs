using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trashlist : MonoBehaviour
{
    public static Trashlist instance;

    public List<string> names = new List<string>();
    public List<string> descs = new List<string>();

    public string n0 = "Fun Flume Log";
    public string d0 = "Ever think about all the other types of fumes besides log? I don't.";

    public string n1 = "Fun Flume";
    public string d1 = "What kind of monster would destroy the Fun Flume?";

    public string n2 = "";
    public string d2 = "";

    public string n3 = "Cone";
    public string d3 = "Cone is an underutilised and frankly disrespected shape.";

    public string n4 = "Water Balloon Dispenser" ;
    public string d4 = "Water balloons help you complete the puzzle.";

    public string n5 = "Castle" ;
    public string d5 = "A princess house. Princesses make excellent garbage. ";

    public string n6 = "";
    public string d6 = "";

    public string n7 = "";
    public string d7 = "";

    public void Start()
    {
        names.Add(n0);
        names.Add(n1);
        names.Add(n2);
        names.Add(n3);
        names.Add(n4);
        names.Add(n5);
        names.Add(n6);
        names.Add(n7);

        descs.Add(d0);
        descs.Add(d1);
        descs.Add(d2);
        descs.Add(d3);
        descs.Add(d4);
        descs.Add(d5);
        descs.Add(d6);
        descs.Add(d7);
    }
}

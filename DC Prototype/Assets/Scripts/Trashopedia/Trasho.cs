using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public string name;
    public string desc;
    public GameObject model;

    public Item(string Name, string Desc, GameObject Model)
    {
        name = Name;
        desc = Desc;
        model = Model;
    }
}

public class Trasho : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Start()
    {

    }

    void Update()
    {
        
    }
}

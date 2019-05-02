using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult_Off : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Off()
    {
        GetComponent<Animator>().enabled = false;
        gameObject.SetActive(false);  
    }
}

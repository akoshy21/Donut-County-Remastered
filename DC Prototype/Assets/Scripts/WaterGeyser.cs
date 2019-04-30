using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGeyser : MonoBehaviour
{
    private ParticleSystem waterShoot;
    public bool waterOn;
    public float waterTimer; 

    void Start()
    {
        waterShoot = GetComponent<ParticleSystem>();
        waterTimer = 0f; 
    }

    void Update()
    {
        waterTimer = waterTimer + Time.deltaTime; 
        var emission = waterShoot.emission;
        emission.enabled = waterOn; //connecting the particle system to the bool

        if(Input.GetKeyDown(KeyCode.W)){
            waterOn = true;
            waterTimer = 0f; 
        }

        if(waterTimer >= 3.5f){
            waterOn = false; 
        }
    }
}

//--AZH
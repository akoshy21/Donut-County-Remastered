using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBubbleFloat : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed;
    float startTime;
    float journeyLength;

    public bool sinCurve = false;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        if (sinCurve)
            fracJourney = Mathf.Sin(fracJourney * Mathf.PI * 0.5f);

        transform.position = Vector3.Slerp(startMarker.position, endMarker.position, fracJourney);

    }
    //what's above will probably match the movement from the game better than what's below 

    //private bool bubbleDown;
    //public float bubbleMoveSpeed = 0.13f;
    //public float moveThreshold = 0.1f;
    //float initPosY;

    //void Start()
    //{
    //    initPosY = transform.position.y;
    //    // all of this just determines the direction the bubble starts going in
    //    // (
    //    int randomNum = Random.Range(0, 10);
    //    if (randomNum > 5){
    //        bubbleDown = true;
    //    }else{
    //        bubbleDown = false;
    //    }
    //    // )
    //}

    //void Update()
    //{
        //if (bubbleDown){
        //    transform.Translate(Vector2.down * bubbleMoveSpeed * Time.deltaTime); //move down
        //}else{
        //    transform.Translate(-Vector2.down * bubbleMoveSpeed * Time.deltaTime); //move back up
        //}

        //if (transform.position.y >= initPosY + moveThreshold){
        //    bubbleDown = true; //move the bubble down if it’s beyond the bounds of where it should move upwards
        //}

        //if (transform.position.y <= initPosY - moveThreshold){
        //    bubbleDown = false; //move the bubble up if it’s beyond the bounds of where it should move downwards
        //}
    //} 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    //public GameObject cursor;
    public Transform cursorPosition;
    public Transform moveTowardsPosition;

    public float cursorSpeed;
    float startTime;
    float journeyLength;

    public LayerMask hitLayers;

    public float cursorRayDistance = 10;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(cursorPosition.position, moveTowardsPosition.position);
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mouse);

        Debug.DrawRay(mouseRay.origin, (mouseRay.direction * cursorRayDistance), Color.red);

        float distCovered = (Time.time - startTime) * cursorSpeed;
        float fracJourney = distCovered / journeyLength;

        RaycastHit cursorHit;
        if (Physics.Raycast(mouseRay, out cursorHit, Mathf.Infinity, hitLayers))
        {
            transform.position = Vector3.Slerp(cursorPosition.position, moveTowardsPosition.position, fracJourney);
            //cursorPosition.transform.position = cursorHit.point; 
        }
    }
}

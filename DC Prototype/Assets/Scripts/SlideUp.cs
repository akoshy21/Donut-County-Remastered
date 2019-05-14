using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUp : MonoBehaviour
{
    public Vector3 pos2;
    public GameObject slide;
    public float speed;
    bool up;
    public GameObject wheel;

    private void Update()
    {
        if(up)
        {
            Debug.Log(pos2);
            slide.transform.position = Vector3.Lerp(slide.transform.position, pos2, speed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("ENTER" + collision.name);
        if(collision.gameObject.tag.Equals("water"))
        {
            up = true;
            wheel.GetComponent<WaterWheel>().goOn = true;
            Debug.Log("WATER");
        }
    }

}

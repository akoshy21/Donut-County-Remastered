using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FerrisWheelSpin : MonoBehaviour
{
    public int count = 0;
    public float rotationAmount, rotationStep;

    public GameObject cam;
    public bool crashed = false;
    bool camMoved = false;
    bool camMovedTwo = false;

    public GameObject castle;

    private void Update()
    {
        if (!crashed)
        {
            this.transform.Rotate(0, 0, rotationStep * Time.deltaTime);

            if (count > 1)
            {
                explodeCastle();
            }
        }

        if(camMoved && !camMovedTwo) {
            StartCoroutine(Wait());
        }
    }

    public void Spin(int num)
    {
        if (num > 1)
        {
            rotationStep += 1;
            if(!camMoved)
            {
                cam.GetComponent<CameraMover>().selectedWP++;
                camMoved = true;
                }



        }
        else {
            count++;
            rotationStep += 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("water"))
        {
            Spin(count);

        }
    }

    void explodeCastle()
    {
        SceneManager.LoadScene("Trashopedia");
        foreach(Castle_Launch cb in castle.transform.GetComponentsInChildren<Castle_Launch>())
        {
            Debug.Log(cb);
            if (cb.gameObject.GetComponent<Castle_Launch>() != null)
            {
                cb.explode = true;
            } 
        }

        infinite.inf.puddle = false;
        infinite.inf.infinitePuddle.SetActive(false);

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        if (!camMovedTwo){
            cam.GetComponent<CameraMover>().selectedWP++;
            camMovedTwo = true;
        }
    }
}

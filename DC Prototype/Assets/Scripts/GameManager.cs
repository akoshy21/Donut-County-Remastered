using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject hole;

    public bool gameScene;
    public bool start;
    public bool paused = false;

    public Camera mainCam;

    public GameObject names;

    public bool intro = false;
    public bool oof = false;

    // makes the GameManager static, and stops it from being destroyed.
    private void Awake()
    {
        // check if there's a manager, if so, destroy this. 
        // otherwise, make this the manager.
        if(manager != null && manager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
      }

    private void Update()
    {
        if (oof)
        {
            StartGame();
        }

        if(intro)
        {
            StartCoroutine(IntroSequence());
        }

        // check if its start and get the mouse button
        if (start && Input.GetMouseButton(0))
        {
            // raycast to see where the mouse is at
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Default")))
            {
                Vector3 hitPos = new Vector3(hit.point.x, -0.12f, hit.point.z); // y is manually set to the y we want

                // move the hole to the mouse point
                hole.GetComponent<Transform>().position = hitPos;
            }
            mainCam.GetComponent<CameraMover>().TriggerSelect(3);

            // turn the hole on, set start to false as we've started
            hole.SetActive(true);
            start = false;
            // Debug.Log("start click");

            // if in gameScene scene, unload the start ui
            if (gameScene)
            {
                SceneManager.UnloadSceneAsync("StartAdditive");
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                SceneManager.LoadScene("PauseScreen", LoadSceneMode.Additive);
                paused = true;
            }
            else
            {
                SceneManager.UnloadSceneAsync("PauseScreen");
            }
        }
    }

    void StartGame()
    {
        names.SetActive(false);
        oof = false;
        this.GetComponent<AudioSource>().Play();
        intro = true;
    }

    IEnumerator IntroSequence()
    {
        intro = false;
        yield return new WaitForSeconds(2);
        mainCam.GetComponent<CameraMover>().TriggerSelect(1);
        Debug.Log("MOVE OVER");
        yield return new WaitForSeconds(4);
        mainCam.GetComponent<CameraMover>().TriggerSelect(2);
        SceneManager.LoadScene("StartAdditive", LoadSceneMode.Additive);
        start = true;

    }
}

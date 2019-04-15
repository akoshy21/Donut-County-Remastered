using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject hole;

    public bool start = true;
    public int score;

    // makes the GameManager static, and stops it from being destroyed.
    private void Awake()
    {
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
        if(start && Input.GetMouseButton(0))
        {
            hole.SetActive(true);
            start = false;
            Debug.Log("click");

            SceneManager.UnloadSceneAsync("StartAdditive");
        }
    }

    // function to score.
    void AddScore(int size)
    {
        score += size * 10;
    }
}

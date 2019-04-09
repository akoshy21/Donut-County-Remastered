using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

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

    // function to score.
    void AddScore(int size)
    {
        score += size * 10;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //button rect transform should mirror raw image rect transform
    private RectTransform myRect;
    public RectTransform myImg;

    //buttons open scenes
    private Button myButton;
    public string myScene;

    void Start()
    {
        myRect = GetComponent<RectTransform>();
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(OpenScene);
    }

    // Update is called once per frame
    void Update()
    {
        myRect.sizeDelta = myImg.sizeDelta;
    }

    void OpenScene()
    {
        Debug.Log("button works");
        //SceneManager.LoadScene(myScene, LoadSceneMode.Additive);
    }
}

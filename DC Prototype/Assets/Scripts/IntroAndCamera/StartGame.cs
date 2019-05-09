using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : StateMachineBehaviour
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (SceneManager.GetActiveScene().name.Equals("cutscene test"))
        {
            GameManager.manager.oof = true;
            GameManager.manager.cutscene = false;
        }
        else {
            GameManager.manager.dialogueCanvas.gameObject.SetActive(false); 
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Debug.Log("FALSE");
    }
}

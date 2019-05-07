using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : StateMachineBehaviour
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        GameManager.manager.oof = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Debug.Log("FALSE");
    }
}

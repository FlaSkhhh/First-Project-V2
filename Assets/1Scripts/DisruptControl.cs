using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptControl : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyController>().BiteClosed();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyController>().BiteClosed();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShots : StateMachineBehaviour
{
    public EnemyController control;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      control = animator.GetComponent<EnemyController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        control.FaceTarget();
        control.AirAttack();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopJumpAttack : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StopJumpAttackReference sjar = animator.GetComponentInChildren<StopJumpAttackReference>();
        if(sjar != null)
        {
            sjar.pmws.canAttack = false;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StopJumpAttackReference sjar = animator.GetComponentInChildren<StopJumpAttackReference>();
        if (sjar != null)
        {
            sjar.pmws.canAttack = true;
        }
    }
}

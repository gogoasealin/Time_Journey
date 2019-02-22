using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithSwordAttack : StateMachineBehaviour
{

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stateInfo.normalizedTime <= 0.4f && animator.GetFloat("Speed") > 0.1f)
        {
            animator.SetTrigger("SwitchSwordAttack");
        }
    }
}

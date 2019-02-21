using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopJumpAttack : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameController.instance.player.GetComponent<PlayerMovementWithSword>().canAttack = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameController.instance.player.GetComponent<PlayerMovementWithSword>().canAttack = true;
    }
}

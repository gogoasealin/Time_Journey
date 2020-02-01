using UnityEngine;

public class StopJumpAttack : StateMachineBehaviour
{
    /// <summary>
    /// Handle the stop jump attack animation
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // get reference to the player animator
        StopJumpAttackReference sjar = animator.GetComponentInChildren<StopJumpAttackReference>();
        if (sjar != null)
        {
            sjar.pmws.canAttack = false;
        }
    }

    /// <summary>
    /// handle the state exit
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StopJumpAttackReference sjar = animator.GetComponentInChildren<StopJumpAttackReference>();
        if (sjar != null)
        {
            sjar.pmws.canAttack = true;
        }
    }
}

using UnityEngine;

public class SwithSwordAttack : StateMachineBehaviour
{
    /// <summary>
    /// handle the attack animation change when already running
    /// </summary>
    /// <param name="animator">animator</param>
    /// <param name="stateInfo">state info</param>
    /// <param name="layerIndex">layer index</param>
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if player change position when already attacking trigger a new sword damage
        if (stateInfo.normalizedTime <= 0.4f && animator.GetFloat("Speed") > 0.1f)
        {
            animator.SetTrigger("SwitchSwordAttack");
            GameController.instance.swordLogic.GetComponent<SwordAttacks>().SwordDamage();
        }
    }
}

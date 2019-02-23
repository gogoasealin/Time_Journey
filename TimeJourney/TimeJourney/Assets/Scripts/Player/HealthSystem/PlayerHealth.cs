using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void Die()
    {
        Debug.Log("i die like this");
        TriggerDeathAnimation();
        Death();
    }

    public override void GetDamageAnimation()
    {
        Debug.Log("dar chiar si in plus");
    }

    public void TriggerDeathAnimation()
    {
        Debug.Log("player death animation");
        //m_animator.SetTrigger("Die");
    }

    public void Death() // called after death animation;
    {
        gameObject.SetActive(false);
        GameController.instance.GameOver();
    }
}

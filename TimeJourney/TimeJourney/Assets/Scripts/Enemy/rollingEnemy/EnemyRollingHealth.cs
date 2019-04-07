using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRollingHealth : Health
{
    public bool getDMG;
    public override void GetDamage(int dmgAmount)
    {
        if(getDMG)
        {
            base.GetDamage(dmgAmount);
        }
    }

    public override void GetDamage(string type, int dmgAmount)
    {
        if (getDMG)
        {
            base.GetDamage(type, dmgAmount);
        }
    }


    //public override void Die()
    //{
    //    Debug.Log("die in special way");
    //    Destroy(gameObject);
    //}

    //public override void GetDamageAnimation()
    //{
    //    Debug.Log("trigger animation in special way");
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Health : Health
{
    public override void Die()
    {
        Debug.Log("i die like this");
        Destroy(gameObject);
    }

    public override void GetDamageAnimation()
    {
        Debug.Log("dar chiar si in plus");
    }
}

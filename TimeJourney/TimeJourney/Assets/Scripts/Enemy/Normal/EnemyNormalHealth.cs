﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalHealth : Health
{
    public override void Die()
    {
        Debug.Log("die in special way");
        Destroy(gameObject);
    }

    public override void GetDamageAnimation()
    {
        Debug.Log("trigger animation in special way");
    }
}
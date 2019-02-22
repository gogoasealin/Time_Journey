using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopJumpAttackReference : MonoBehaviour
{
    public PlayerMovementWithSword pmws;

    void Start()
    {
        pmws = GetComponentInParent<PlayerMovementWithSword>();
    }


}

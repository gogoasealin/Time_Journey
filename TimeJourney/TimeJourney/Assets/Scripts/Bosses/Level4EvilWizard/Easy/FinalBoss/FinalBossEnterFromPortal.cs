﻿using UnityEngine;

public class FinalBossEnterFromPortal : MonoBehaviour
{
    private void Update()
    {
        transform.localScale += new Vector3(0.001f, 0.001f, 0);
        if (transform.localScale.x >= 0.1f)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0);
            GetComponent<FinalBossMovement>().Attack();
            enabled = false;
        }
    }
}

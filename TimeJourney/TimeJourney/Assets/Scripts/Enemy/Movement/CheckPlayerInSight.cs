﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInSight : MonoBehaviour
{
    private EnemyMovement em;

    private void Start()
    {
        em = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            em.m_playerPosition = other.transform.position;
            em.m_playerInSight = true;
        }
    }

}

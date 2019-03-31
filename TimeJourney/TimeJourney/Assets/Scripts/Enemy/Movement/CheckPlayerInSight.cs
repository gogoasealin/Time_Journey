using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInSight : MonoBehaviour
{
    private EnemyMovement em;
    public bool inSight;

    private void Start()
    {
        em = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            em.m_checkLastPosition = false;
            em.m_playerInSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        em.m_playerInSight = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInMoveZone : MonoBehaviour
{
    public EnemyMovement em;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && other.gameObject.transform.parent.Equals(transform.parent))
        {
            em.PlayerOutOfSight();
        }
    }
}

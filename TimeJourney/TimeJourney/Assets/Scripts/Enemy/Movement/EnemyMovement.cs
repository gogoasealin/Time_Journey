using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool m_playerInSight;
    public float m_movementSpeed;
    protected Animator anim;
    protected Rigidbody2D rb2d;

    protected virtual void Patrol() {; }
    protected virtual void ChasePlayer(){; }
    protected virtual void Attack(){; }
    protected virtual void Flip() {; }
    public virtual void PlayerInSight() {; }
    public virtual void PlayerOutOfSight() {; }

}

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // player is sight status
    public bool m_playerInSight;

    // movement speed
    public float m_movementSpeed;

    // refence to animator
    protected Animator anim;

    // reference to rigid body 2d
    protected Rigidbody2D rb2d;

    /// <summary>
    /// Patrol
    /// </summary>
    protected virtual void Patrol() {; }

    /// <summary>
    /// Chase player
    /// </summary>
    protected virtual void ChasePlayer() {; }

    /// <summary>
    /// Attack
    /// </summary>
    protected virtual void Attack() {; }

    /// <summary>
    /// Flip
    /// </summary>
    protected virtual void Flip() {; }

    /// <summary>
    /// PlayerInSight
    /// </summary>
    public virtual void PlayerInSight() {; }

    /// <summary>
    /// PlayerOutOfSight
    /// </summary>
    public virtual void PlayerOutOfSight() {; }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator animator;
    public Rigidbody2D m_Rigidbody2D;

    public float runSpeed = 30f;
    public bool m_FacingRight;  // For determining which way the player is currently facing.

    float horizontalMove = 0f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    private Vector3 m_Velocity = Vector3.zero;

    void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }

    void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime);
    }

    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (move > 0 && !m_FacingRight)
        {
            Flip(0.3f);
        }
        else if (move < 0 && m_FacingRight)
        {
            Flip(-0.3f);
        }
    }

    private void Flip(float moveDistantion)
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
        transform.position += new Vector3(moveDistantion, 0, 0);

    }

}

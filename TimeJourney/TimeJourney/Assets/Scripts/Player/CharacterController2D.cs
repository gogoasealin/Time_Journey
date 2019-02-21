using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 200f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	public LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
    public Transform m_GroundCheck;							// A position marking where to check if the player is grounded.

	const float k_GroundedRadius = .2f;//era 0.1 // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	public bool m_FacingRight;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

    public Animator animator;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		m_Grounded = false;
        animator.SetBool("IsGrounded", false);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
            if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
                animator.SetBool("IsGrounded", true);
                OnLandEvent.Invoke();                
            }
		}        
    }

	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            //m_Rigidbody2D.MovePosition(Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing));

			if (move > 0 && !m_FacingRight)
			{
				Flip(0.3f);
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip(-0.3f);
			}
		}

		if (m_Grounded && jump)
		{
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            SetGrounded();
        }             
    }

    public void SetGrounded()
    {
        m_Grounded = false;
        animator.SetBool("IsGrounded", false);
    }

	private void Flip(float moveDistantion)
	{
		m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
        transform.position += new Vector3(moveDistantion, 0, 0);

	}
}

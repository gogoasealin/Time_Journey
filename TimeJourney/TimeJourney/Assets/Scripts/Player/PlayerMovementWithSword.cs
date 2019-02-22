using UnityEngine;

public class PlayerMovementWithSword : MonoBehaviour {

    public CharacterController2D controller;
    [HideInInspector]public Animator animator;

    //movement
    public float runSpeed;
    [HideInInspector] public float horizontalMove;
    private bool jump = false;

    public bool canAttack; // stop spaming attacks

    private void Start()
    {
        canAttack = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Jump();
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void Jump()
    {
        animator.SetBool("IsJumping", true);
    }

    public void DisableAttack()
    {
        canAttack = false;
    }

    public void EnableAttack()
    {
        canAttack = true;
    }
}

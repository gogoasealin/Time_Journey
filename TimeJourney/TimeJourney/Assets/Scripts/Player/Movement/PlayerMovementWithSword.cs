using UnityEngine;

public class PlayerMovementWithSword : MonoBehaviour
{

    public CharacterController2D controller;
    [HideInInspector] public Animator animator;

    //movement
    public float runSpeed;
    [HideInInspector] public float horizontalMove;
    private bool jump = false;

    public bool canAttack; // stop spaming attacks
    [Tooltip("The script for StoneAttack from stone logic")]
    public StoneAttacks stoneAttacks;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        canAttack = true;
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

    public void Shot()
    {
        stoneAttacks.Shot();
    }
}

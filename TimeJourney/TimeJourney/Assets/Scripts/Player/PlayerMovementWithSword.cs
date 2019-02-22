using UnityEngine;

public class PlayerMovementWithSword : MonoBehaviour {

    public CharacterController2D controller;
    [HideInInspector]public Animator animator;

    //movement
    public float runSpeed;
    [HideInInspector] public float horizontalMove;
    bool jump = false;

    //atacking
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

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

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Attack();
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

    public void Attack()
    {
        canAttack = false;
        animator.SetTrigger("SwordAttack");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length;++i)
        {
            if (!enemiesToDamage[i].isTrigger)
            {
                Debug.Log(enemiesToDamage[i].name);
            }
        }
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

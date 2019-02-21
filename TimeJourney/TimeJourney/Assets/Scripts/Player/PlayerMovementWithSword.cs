using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithSword : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    //movement
    public float runSpeed;
    float horizontalMove;
    bool jump = false;

    //atacking
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Invoke("Jump", 0.15f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            StoneAttack();
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

    public void StoneAttack()
    {
        animator.SetTrigger("StoneAttack");
    }

    public void Attack()
    {
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

    public void StopAttack()
    {
        animator.SetBool("Attacking", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithSword : MonoBehaviour {

    [SerializeField] CharacterController2D controller;
    [SerializeField] Animator animator;

    public float runSpeed = 7f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
 //   bool attack = false;
    [SerializeField] bool oneJump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Invoke("Jump", 0.15f);

            //Debug.Log("attacking " + animator.GetBool("Attacking"));
            //Debug.Log(" grounded : " + controller.m_Grounded);
            //if (animator.GetBool("Attacking") && !oneJump)
            //{
            //    controller.Invoke("ForceJump", 0.15f);
            //    oneJump = true;
            //    controller.Invoke("SetGrounded", 0.15f);
            //}

        }

        if(Input.GetMouseButtonDown(0))
        {
            //attack = true;
            animator.SetBool("Attacking", true);
        }
      
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        oneJump = false;
    }

    public void Jump()
    {
        animator.SetBool("IsJumping", true);
    }

    public void Attack()
    {
        animator.SetBool("Attacking", true);
    }

    public void StopAttack()
    {
        //attack = false;
        animator.SetBool("Attacking", false);
    }
}

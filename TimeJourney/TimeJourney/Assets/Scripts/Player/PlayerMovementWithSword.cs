using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithSword : MonoBehaviour {

    [SerializeField] CharacterController2D controller;
    [SerializeField] Animator animator;
    [SerializeField] GameObject stone;
    [SerializeField] GameObject stoneForAttack;

    //movement
    public float runSpeed;
    float horizontalMove;
    bool jump = false;
    bool crouch = false; 
    public int count = 0;


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

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Time.timeScale = 1f;
        //}

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
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
        if(!animator.GetBool("IsJumping"))
        {
            stone.SetActive(false);
            stoneForAttack.SetActive(true);
        }
        animator.SetBool("Attacking", true);
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
        //attack = false;
        animator.SetBool("Attacking", false);
        stoneForAttack.SetActive(false);
        stone.SetActive(true);

    }

    void StonePosition()
    {
        Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
        
        if (currentSprite.name == "player_attack_01Sprite")
        {
            stoneForAttack.transform.localPosition = new Vector3(-0.254f, -0.1f, 0f);
            //Time.timeScale = 0f;

        }
        else if (currentSprite.name == "player_attack_03Sprite")
        {
            stoneForAttack.transform.localPosition = new Vector3(-0.274f, -0.131f, 0f);
            //Time.timeScale = 0f;

        }
        else if (currentSprite.name == "player_attack_05Sprite")
        {
            stoneForAttack.transform.localPosition = new Vector3(-0.186f, -0.061f, 0f);
            //Time.timeScale = 0f;
        }
        else
        {
            stoneForAttack.transform.localPosition = new Vector3(-0.147f, -0.111f, 0f);
           //Time.timeScale = 0f;
        }

    }


}

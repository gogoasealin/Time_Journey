using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour {

    public Animator anim;
    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public float attackRange;
    private bool canAttack;

    private float count;
    private void Start()
    {
        canAttack = true;
        count = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.isTrigger && canAttack)
        {
            ++count;
            Debug.Log(count);
            Debug.Log(other.name);
            anim.SetBool("attack", true);
            canAttack = false;
            Attack();
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.isTrigger && canAttack)
        {
            anim.SetBool("attack", true);
            canAttack = false;
            Attack();
        }
    }

    private void Attack()
    {

        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
        for(int i = 0; i< playerToDamage.Length; ++i)
        {
            if(playerToDamage[i].isTrigger)
            {
                Debug.Log("Player get dmg" + playerToDamage[i].name);
            }
        }
    }

    private void CanAttack()
    {
        canAttack = true;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(attackPos.position, attackRange);
    //}

}

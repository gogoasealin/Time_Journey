using System;
using UnityEngine;

public class SwordAttacks : MonoBehaviour
{
    public Action FireWeapon = delegate { };
    private PlayerMovementWithSword pmws;

    //atacking
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange = 0.2f;

    void Start()
    {
        pmws = GameController.instance.player.GetComponent<PlayerMovementWithSword>();
        FireWeapon = SwordAttack;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && pmws.canAttack)
        {
            SwordAttack();
        }
       
    }

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(attackPos.position, attackRange);
    //}

    private void SwordAttack()
    {
        SwordAnimation();
        SwordDamage();
    }

    public void SwordAnimation()
    {
        pmws.canAttack = false;
        pmws.animator.SetTrigger("SwordAttack");
    }

    public void SwordDamage()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; ++i)
        {
            if (!enemiesToDamage[i].isTrigger)
            {
                Debug.Log(enemiesToDamage[i].name);
            }
            Debug.Log(enemiesToDamage[i].name);
        }
    }
}

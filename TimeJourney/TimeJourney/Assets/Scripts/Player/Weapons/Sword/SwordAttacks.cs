using System;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttacks : MonoBehaviour
{
    public Action FireWeapon = delegate { };
    private PlayerMovementWithSword pmws;

    //atacking
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsEnemiesTrigger;

    public float attackRange = 0.2f;
    public int swordDamageAmount;

    private List<GameObject> enemyWhoReceivedDamage = new List<GameObject>();

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

    private void SwordAttack()
    {
        SwordAnimation();
        InvokeRepeating("SwordDamage", 0, .1f);
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
                if (!enemyWhoReceivedDamage.Contains(enemiesToDamage[i].gameObject))
                {
                    enemiesToDamage[i].GetComponent<Health>().GetDamage(swordDamageAmount);
                    enemyWhoReceivedDamage.Add(enemiesToDamage[i].gameObject);
                }
            }
        }

        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemiesTrigger);

        for (int i = 0; i < enemiesToDamage.Length; ++i)
        {
            if (enemiesToDamage[i].isTrigger)
            {
                if (!enemyWhoReceivedDamage.Contains(enemiesToDamage[i].gameObject))
                {
                    enemiesToDamage[i].GetComponent<Health>().GetDamage(swordDamageAmount);
                    enemyWhoReceivedDamage.Add(enemiesToDamage[i].gameObject);
                }
            }
        }
    }

    public void StopAttacking()
    {
        CancelInvoke("SwordDamage");
        enemyWhoReceivedDamage.Clear();
    }
}

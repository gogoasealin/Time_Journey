using System;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttacks : MonoBehaviour
{
    // reference to fire weapon action
    public Action FireWeapon = delegate { };
    // reference to pmws
    private PlayerMovementWithSword pmws;
    //atacking
    public Transform attackPos;
    // what is enemies
    public LayerMask whatIsEnemies;
    // what is enemiesTrigger
    public LayerMask whatIsEnemiesTrigger;
    // attack range
    public float attackRange = 0.8f;
    // sword damage amount
    public int swordDamageAmount;
    // enemy who received damage 
    private List<GameObject> enemyWhoReceivedDamage = new List<GameObject>();

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        pmws = GameController.instance.player.GetComponent<PlayerMovementWithSword>();
        FireWeapon = SwordAttack;
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && pmws.canAttack)
        {
            SwordAttack();
        }
    }

    /// <summary>
    /// Sword attack
    /// </summary>
    private void SwordAttack()
    {
        SwordAnimation();
        InvokeRepeating("SwordDamage", 0, .1f);
    }

    /// <summary>
    /// Sword animation
    /// </summary>
    public void SwordAnimation()
    {
        pmws.canAttack = false;
        pmws.animator.SetTrigger("SwordAttack");
    }

    /// <summary>
    /// Sword damage
    /// </summary>
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

    /// <summary>
    /// Stop Attacking
    /// </summary>
    public void StopAttacking()
    {
        CancelInvoke("SwordDamage");
        enemyWhoReceivedDamage.Clear();
    }
}

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

    // Update is called once per frame
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
        SwordAttack();
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
        }
    }
}

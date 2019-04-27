using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalHealth : Health
{
    //public bool m_hasDamageAnimation = true;
    //[HideInInspector] public Animator m_animator;

    public bool weakAtFire;
    public bool ImuneAtFire;
    public bool weakAtIce;
    public bool ImuneAtIce;
    public bool weakAtLight;
    public bool ImuneAtLight;


    public override void Start()
    {
        base.Start();
       // m_animator = GetComponent<Animator>();
    }



    public override void GetDamage(int dmgAmount)
    {
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        //if (m_hasDamageAnimation)
        //{
        //    GetDamageAnimation();
        //}
    }

    public override void GetDamage(string type, int dmgAmount)
    {
        switch (type)
        {
            case "Fire":
                if (ImuneAtFire)
                {
                    return;
                }
                if (weakAtFire)
                {
                    m_CurrentHealth -= dmgAmount * 3;
                }
                else
                {
                    m_CurrentHealth -= dmgAmount;
                }
                break;
            case "Ice":
                if (ImuneAtIce)
                {
                    return;
                }
                if (weakAtIce)
                {
                    m_CurrentHealth -= dmgAmount * 3;
                }
                else
                {
                    m_CurrentHealth -= dmgAmount;
                }
                break;
            case "Light":
                if (ImuneAtLight)
                {
                    return;
                }
                if (weakAtLight)
                {
                    m_CurrentHealth -= dmgAmount * 3;
                }
                else
                {
                    m_CurrentHealth -= dmgAmount;
                }
                break;
            default:
                m_CurrentHealth -= dmgAmount;
                Debug.Log("something is not ok");
                break;
        }

        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        //if (m_hasDamageAnimation)
        //{
        //    GetDamageAnimation();
        //}
    }

    public override void Die()
    {
        Debug.Log("die in special way");
        Destroy(gameObject);
    }

    public override void GetDamageAnimation()
    {
        
        Debug.Log("trigger animation in special way");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int m_maxHp;
    private int m_CurrentHealth;

    public bool m_hasDamageAnimation = true;
    [HideInInspector]public Animator m_animator;

    public bool weakAtFire;
    public bool weakAtIce;
    public bool weakAtLight;


    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_CurrentHealth = m_maxHp;
    }

    public virtual void GetDamage(int dmgAmount)
    {
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        if (m_hasDamageAnimation)
        {
            GetDamageAnimation();
        }
    }

    public virtual void GetDamage(string type, int dmgAmount)
    {
        switch(type)
        {
            case "Fire":
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
        if (m_hasDamageAnimation)
        {
            GetDamageAnimation();
        }
    }

    public virtual void Die()
    {
        Debug.Log(gameObject.name + " has die in normal way");
        gameObject.SetActive(false);
    }

    public virtual void GetDamageAnimation()
    {
        Debug.Log("trigger get dmg animation has played in normal way");
        //m_animator.SetTrigger("GetDamage");
    }

}

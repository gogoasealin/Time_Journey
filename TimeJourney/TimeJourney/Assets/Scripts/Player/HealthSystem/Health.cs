using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int m_maxHp;
    public bool m_hasDamageAnimation;
    [HideInInspector]public Animator m_animator;

    public bool weakAtFire;
    public bool weakAtIce;
    public bool weakAtLight;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public virtual void GetDamage(int dmgAmount)
    {
        m_maxHp -= dmgAmount;
        if (m_maxHp <= 0)
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
                    m_maxHp -= dmgAmount * 3;
                }
                else
                {
                    m_maxHp -= dmgAmount;
                }
                break;
            case "Ice":
                if (weakAtIce)
                {
                    m_maxHp -= dmgAmount * 3;
                }
                else
                {
                    m_maxHp -= dmgAmount;
                }
                break;
            case "Light":
                if (weakAtLight)
                {
                    m_maxHp -= dmgAmount * 3;
                }
                else
                {
                    m_maxHp -= dmgAmount;
                }
                break;
            default:
                m_maxHp -= dmgAmount;
                Debug.Log("something is not ok");
                break;
        }

        if (m_maxHp <= 0)
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
        Debug.Log("trigger set animation has played");
        //m_animator.SetTrigger("GetDamage");
    }

}

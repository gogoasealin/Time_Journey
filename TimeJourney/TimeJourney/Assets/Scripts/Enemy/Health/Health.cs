using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int m_maxHp;
    protected int m_CurrentHealth;

    public virtual void Start()
    {
        m_CurrentHealth = m_maxHp;
    }

    public virtual void GetDamage(int dmgAmount)
    {
    }

    public virtual void GetDamage(string type, int dmgAmount)
    {
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

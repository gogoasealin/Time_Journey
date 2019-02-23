using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image m_HurtImage;
    public float m_maxHp;

    [HideInInspector] public Animator m_animator;

    [SerializeField]private float m_currentHealth;
    public float m_CurrentHealth
    {
        get { return m_currentHealth; }
        set {
            m_currentHealth = value;
            SetHealth(m_currentHealth);  
        }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_CurrentHealth = m_maxHp;
    }

    public void GetDamage(int dmgAmount)
    {
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        GetDamageAnimation();
    }


    public void Die()
    {
        Debug.Log("i die like this");
        TriggerDeathAnimation();
        Death();
    }

    public void GetDamageAnimation()
    {
        Debug.Log("GetDamageAnimation");
        //dmgAnimation;
        GetComponent<PlayerRegeneration>().m_DamageReceive = true;
    }

    public void TriggerDeathAnimation()
    {
        Debug.Log("player death animation");
        //m_animator.SetTrigger("Die");
    }

    public void Death() // called after death animation;
    {
        gameObject.SetActive(false);
        GameController.instance.GameOver();
    }

    public void SetHealth(float currentHP)
    {
        float currentHPLost = (m_maxHp - m_currentHealth) / 100;
        m_HurtImage.color = new Color (1,0,0, currentHPLost);
    }

}

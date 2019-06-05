using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image m_HurtImage;
    public float m_maxHp;

    [HideInInspector] public Animator m_animator;
    private IEnumerator damageAnimation;

    public SpriteRenderer[] bodyParts;

    private bool damageReceived;


    [SerializeField] private float m_currentHealth;
    public float m_CurrentHealth
    {
        get { return m_currentHealth; }
        set
        {
            m_currentHealth = value;
            SetHealth();
        }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_CurrentHealth = m_maxHp;
    }

    public void GetDamage(int dmgAmount)
    {
        if (damageReceived)
        {
            return;
        }
        damageReceived = true;
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        GetDamageAnimation();
    }



    public void GetDamageAnimation()
    {
        damageAnimation = DamageAnimation();
        StartCoroutine(damageAnimation);
    }

    public IEnumerator DamageAnimation()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < bodyParts.Length; j++)
            {
                bodyParts[j].enabled = !bodyParts[j].enabled;
            }
            yield return new WaitForSeconds(.1f);
        }
        GetComponent<PlayerRegeneration>().m_DamageReceive = true;
        damageReceived = false;
    }


    public void Die()
    {
        TriggerDeathAnimation();
        Death();
    }

    public void TriggerDeathAnimation()
    {
        m_animator.SetFloat("Speed", 0);
        m_animator.SetBool("IsGrounded", true);
    }

    public void Death() // called after death animation;
    {
        GameController.instance.GameOver();
    }

    public void SetHealth()
    {
        float currentHPLost = (m_maxHp - m_currentHealth) / 100;
        m_HurtImage.color = new Color(1, 0, 0, currentHPLost);
    }

}

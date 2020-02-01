using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // refernce to hurt Image
    public Image m_HurtImage;

    // max player hp
    public float m_maxHp;

    // reference to player animator
    [HideInInspector] public Animator m_animator;

    // coroutine for damage animation
    private IEnumerator damageAnimation;

    // reference for body parts
    public SpriteRenderer[] bodyParts;

    // receiving damage status
    private bool damageReceived;

    // current healt
    [SerializeField] private float m_currentHealth;

    // get/set current healt
    public float m_CurrentHealth
    {
        get => m_currentHealth;
        set
        {
            m_currentHealth = value;
            SetDamageImage();
        }
    }

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_CurrentHealth = m_maxHp;
    }



    /// <summary>
    /// Receive damage from hit with sword
    /// </summary>
    /// <param name="dmgAmount">amount of damage to receive</param>
    /// <param name="specialAction">special action status</param>
    public void GetDamage(int dmgAmount, bool specialAction = false)
    {
        // check if received damage
        if (damageReceived)
        {
            return;
        }
        damageReceived = true;
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            if (specialAction)
            {
                GameController.instance.DoSpecialAction();
            }
            Die();
            return;
        }
        GetDamageAnimation();
    }

    /// <summary>
    /// Play animation for receiving damage
    /// </summary>
    public void GetDamageAnimation()
    {
        damageAnimation = DamageAnimation();
        StartCoroutine(damageAnimation);
    }

    /// <summary>
    /// Play receivin damage animation
    /// </summary>
    /// <returns></returns>
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


    /// <summary>
    /// Logic when the current object die
    /// </summary>
    public void Die()
    {
        TriggerDeathAnimation();
        Death();
    }

    /// <summary>
    /// Trigger death animation
    /// </summary>
    public void TriggerDeathAnimation()
    {
        m_animator.SetFloat("Speed", 0);
        m_animator.SetBool("IsGrounded", true);
    }

    /// <summary>
    /// Trigger player death
    /// </summary>
    public void Death() // called after death animation;
    {
        GameController.instance.GameOver();
    }

    /// <summary>
    /// Set damage Image
    /// </summary>
    public void SetDamageImage()
    {
        float currentHPLost = (m_maxHp - m_currentHealth) / 100;
        m_HurtImage.color = new Color(1, 0, 0, currentHPLost);
    }

    /// <summary>
    /// Revive
    /// </summary>
    public void Revive()
    {
        m_currentHealth = m_maxHp;
        SetDamageImage();
        damageReceived = false;
    }
}
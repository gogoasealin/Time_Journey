using System.Collections;
using UnityEngine;

public class EnemyNormalHealth : Health
{
    //[HideInInspector] public Animator m_animator;

    // Coroutine for damage animation 
    private IEnumerator damageAnimation;

    // reference to particle system
    private ParticleSystem body;

    // weak at fire status
    public bool weakAtFire;

    // imune at fire status
    public bool ImuneAtFire;

    // weak at ice status
    public bool weakAtIce;

    // imune at ice status
    public bool ImuneAtIce;

    // weak at light status
    public bool weakAtLight;

    // imune at light status
    public bool ImuneAtLight;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    public override void Start()
    {
        base.Start();
        body = GetComponentInChildren<ParticleSystem>();
        // m_animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Receive damage from hit (with sword for enemy, and by enemy body for player)
    /// </summary>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public override void GetDamage(int dmgAmount)
    {
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        GetComponent<EnemyNormalMovement>().PlayerInSight();
        GetDamageAnimation();
    }

    /// <summary>
    /// Receive damage from player stones
    /// </summary>
    /// <param name="type">stone attack type (fire, ice, light)</param>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public override void GetDamage(string type, int dmgAmount)
    {
        switch (type)
        {
            case "Fire":
                HandleFireDamage(dmgAmount);
                break;
            case "Ice":
                HandleIceDamage(dmgAmount);
                break;
            case "Light":
                HandleLightDamage(dmgAmount);
                break;
            default:
                m_CurrentHealth -= dmgAmount;
                break;
        }
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        GetComponent<EnemyNormalMovement>().PlayerInSight();
        GetDamageAnimation();
    }

    /// <summary>
    /// Handle fire Damage
    /// </summary>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public void HandleFireDamage(int dmgAmount)
    {
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
    }

    /// <summary>
    /// Handle Ice Damage
    /// </summary>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public void HandleIceDamage(int dmgAmount)
    {
        if (ImuneAtIce)
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
    }

    /// <summary>
    /// Handle Light Damage
    /// </summary>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public void HandleLightDamage(int dmgAmount)
    {
        if (ImuneAtLight)
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
    }

    /// <summary>
    /// Logic when the current object die
    /// </summary>
    public override void Die()
    {
        Destroy(transform.parent.gameObject);
    }

    /// <summary>
    /// Play animation for receiving damage
    /// </summary>
    public override void GetDamageAnimation()
    {
        PrepareNextDamageAnimation();
        damageAnimation = DamageAnimation();
        StartCoroutine(damageAnimation);
    }

    /// <summary>
    /// Set all body parts as visible
    /// </summary>
    public void PrepareNextDamageAnimation()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Play receivin damage animation
    /// </summary>
    /// <returns></returns>
    public IEnumerator DamageAnimation()
    {
        for (int i = 0; i < 13; i++)
        {
            if (body.isPlaying)
            {
                body.Stop();
            }
            else
            {
                body.Play();
            }
            yield return new WaitForSeconds(.1f);

        }
        body.Play();
    }

}
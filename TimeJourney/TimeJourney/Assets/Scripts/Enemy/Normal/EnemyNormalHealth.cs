using System.Collections;
using UnityEngine;

public class EnemyNormalHealth : Health
{
    //[HideInInspector] public Animator m_animator;

    private IEnumerator damageAnimation;
    private ParticleSystem body;

    public bool weakAtFire;
    public bool ImuneAtFire;
    public bool weakAtIce;
    public bool ImuneAtIce;
    public bool weakAtLight;
    public bool ImuneAtLight;


    public override void Start()
    {
        base.Start();
        body = GetComponentInChildren<ParticleSystem>();
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
        GetComponent<EnemyNormalMovement>().PlayerInSight();
        GetDamageAnimation();
    }

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

    public override void Die()
    {
        Destroy(transform.parent.gameObject);
    }

    public override void GetDamageAnimation()
    {
        PrepareNextDamageAnimation();
        damageAnimation = DamageAnimation();
        StartCoroutine(damageAnimation);
    }

    public void PrepareNextDamageAnimation()
    {
        StopAllCoroutines();
    }

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
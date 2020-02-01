using System.Collections;
using UnityEngine;

public class EvilWizardNormalHealth : Health
{
    // Coroutine for damage animation
    private IEnumerator damageAnimation;

    // reference for body parts
    public SpriteRenderer[] bodyParts;

    //receiving damage status
    public bool receiveDMG;

    // reference for sceneCollider
    public GameObject sceneCollider;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    public override void Start()
    {
        base.Start();
    }

    /// <summary>
    /// Receive damage from hit with sword
    /// </summary>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public override void GetDamage(int dmgAmount)
    {
        if (!receiveDMG)
        {
            return;
        }
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        GetDamageAnimation();
        SetBossColorState(false);
    }

    /// <summary>
    /// Receive damage from player stones
    /// </summary>
    /// <param name="type">stone attack type (fire, ice, light)</param>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public override void GetDamage(string type, int dmgAmount)
    {
        if (!receiveDMG)
        {
            return;
        }
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        GetDamageAnimation();
        SetBossColorState(false);

    }

    /// <summary>
    /// Set boss damage receiving status (color)
    /// </summary>
    /// <param name="canReceiveDamage"></param>
    public void SetBossColorState(bool canReceiveDamage)
    {
        Color newColor;
        if (canReceiveDamage)
        {
            newColor = new Color(1, 0, 0.3f);
            receiveDMG = true;
        }
        else
        {
            newColor = new Color(1, 1, 1);
            receiveDMG = false;
        }

        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<SpriteRenderer>().color = newColor;
        }
    }

    /// <summary>
    /// Play animation for receiving damage
    /// </summary>
    public override void GetDamageAnimation()
    {
        damageAnimation = DamageAnimation();
        PrepareNextDamageAnimation();
        StartCoroutine(damageAnimation);
    }

    /// <summary>
    /// Set all body parts as visible
    /// </summary>
    public void PrepareNextDamageAnimation()
    {
        StopAllCoroutines();
        for (int j = 0; j < bodyParts.Length; j++)
        {
            bodyParts[j].enabled = true;
        }
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
    }

    /// <summary>
    /// Logic when the current object die
    /// </summary>
    public override void Die()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }

        Invoke("Disable", 1f);

    }

    void Disable()
    {
        gameObject.SetActive(false);
        sceneCollider.SetActive(false);
    }
}

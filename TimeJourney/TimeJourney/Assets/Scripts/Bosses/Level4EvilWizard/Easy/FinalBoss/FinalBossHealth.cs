using System.Collections;
using UnityEngine;

public class FinalBossHealth : Health
{
    private IEnumerator damageAnimation;
    public SpriteRenderer[] bodyParts;
    public TriggerBossFightWizard triggerBossFight;
    public bool receiveDMG;

    public override void Start()
    {
        base.Start();
    }

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

    public override void GetDamageAnimation()
    {
        damageAnimation = DamageAnimation();
        PrepareNextDamageAnimation();
        StartCoroutine(damageAnimation);
    }
    public void PrepareNextDamageAnimation()
    {
        StopAllCoroutines();
        for (int j = 0; j < bodyParts.Length; j++)
        {
            bodyParts[j].enabled = true;
        }
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
    }

    public override void Die()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
        triggerBossFight.Revert();
    }

}

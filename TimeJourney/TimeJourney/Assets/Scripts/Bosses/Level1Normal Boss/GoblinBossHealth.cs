using System.Collections;
using UnityEngine;

public class GoblinBossHealth : Health
{
    [HideInInspector] public Animator anim;
    private IEnumerator damageAnimation;
    public SpriteRenderer[] bodyParts;
    public TriggerBossFight triggerBossFight;

    private void OnEnable()
    {
        transform.localScale = new Vector3(0.003f, 0.003f, 0);
        m_CurrentHealth = m_maxHp;
        GetComponent<GoblinBossEnter>().enabled = true;
    }

    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    public override void GetDamage(int dmgAmount)
    {
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        GetDamageAnimation();
    }

    public override void GetDamage(string type, int dmgAmount)
    {
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
        GetDamageAnimation();
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
        triggerBossFight.Revert();
    }
}

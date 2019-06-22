using System.Collections;
using UnityEngine;

public class PurpleGoblinHealthNormal : Health
{
    private IEnumerator damageAnimation;
    private SpriteRenderer bodyParts;
    public TriggerBossFight triggerBossFight;
    private Vector3 spawnPosition;
    public bool receiveDMG;

    private void OnEnable()
    {
        m_CurrentHealth = m_maxHp;
        transform.position = spawnPosition;
        receiveDMG = false;
    }

    private void Awake()
    {
        spawnPosition = transform.position;
    }

    public override void Start()
    {
        base.Start();

        bodyParts = GetComponentInChildren<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Water"))
        {
            receiveDMG = true;
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 0, 0.3f);
            Invoke("DisableDamage", 3f);
        }
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
        DisableDamage();
        CancelInvoke("DisableDamage");
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
        DisableDamage();
        CancelInvoke("DisableDamage");
    }

    public void DisableDamage()
    {
        receiveDMG = false;
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1f);
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
        bodyParts.enabled = true;
    }

    public IEnumerator DamageAnimation()
    {
        for (int i = 0; i < 12; i++)
        {
            bodyParts.enabled = !bodyParts.enabled;
            yield return new WaitForSeconds(.1f);
        }
    }

    public override void Die()
    {
        triggerBossFight.Revert();
    }
}

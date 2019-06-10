using UnityEngine;

public class GoblinBossHealth : Health
{
    [HideInInspector] public Animator anim;

    private void OnEnable()
    {
        transform.localScale = new Vector3(0.003f, 0.003f, 0);
        m_CurrentHealth = m_maxHp;
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
    }

    public override void GetDamage(string type, int dmgAmount)
    {
        m_CurrentHealth -= dmgAmount;
        if (m_CurrentHealth <= 0)
        {
            Die();
            return;
        }
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}

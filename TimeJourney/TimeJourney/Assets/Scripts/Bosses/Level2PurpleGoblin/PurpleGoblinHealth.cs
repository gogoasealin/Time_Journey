using System.Collections;
using UnityEngine;

public class PurpleGoblinHealth : Health
{
    private IEnumerator damageAnimation;
    private SpriteRenderer bodyParts;
    public TriggerBossFight triggerBossFight;
    private Vector3 spawnPosition;

    private void OnEnable()
    {
        m_CurrentHealth = m_maxHp;
        transform.position = spawnPosition;
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
        if (other.name.Contains("Pickable") && other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("RedBox"))
        {
            other.gameObject.SetActive(false);
            m_CurrentHealth -= 10;
            if (m_CurrentHealth <= 0)
            {
                Die();
                return;
            }
            GetDamageAnimation();
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

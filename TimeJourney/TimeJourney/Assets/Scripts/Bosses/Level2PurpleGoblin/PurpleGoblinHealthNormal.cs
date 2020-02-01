using System.Collections;
using UnityEngine;

public class PurpleGoblinHealthNormal : Health
{
    // Coroutine for damage animation
    private IEnumerator damageAnimation;

    // reference for body parts
    private SpriteRenderer bodyParts;

    //reference for TriggerBossFight script
    public TriggerBossFight triggerBossFight;

    //position where to spawn
    private Vector3 spawnPosition;

    //receiving damage status
    public bool receiveDMG;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        m_CurrentHealth = m_maxHp;
        transform.position = spawnPosition;
        receiveDMG = false;
    }

    /// <summary>
    /// MonoBehaviour Awake function
    /// </summary>
    private void Awake()
    {
        spawnPosition = transform.position;
    }

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    public override void Start()
    {
        base.Start();

        bodyParts = GetComponentInChildren<SpriteRenderer>();
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Water"))
        {
            receiveDMG = true;
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 0, 0.3f);
            Invoke("DisableDamage", 3f);
        }
    }

    /// <summary>
    /// Receive damage from hit (with sword for enemy, and by enemy body for player)
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
        DisableDamage();
        CancelInvoke("DisableDamage");
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
        DisableDamage();
        CancelInvoke("DisableDamage");
    }

    /// <summary>
    /// Stop the receiving damage animation
    /// </summary>
    public void DisableDamage()
    {
        receiveDMG = false;
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1f);
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
        bodyParts.enabled = true;
    }

    /// <summary>
    /// Play receivin damage animation
    /// </summary>
    /// <returns></returns>
    public IEnumerator DamageAnimation()
    {
        for (int i = 0; i < 12; i++)
        {
            bodyParts.enabled = !bodyParts.enabled;
            yield return new WaitForSeconds(.1f);
        }
    }

    /// <summary>
    /// Logic when the current object die
    /// </summary>
    public override void Die()
    {
        triggerBossFight.Revert();
    }
}

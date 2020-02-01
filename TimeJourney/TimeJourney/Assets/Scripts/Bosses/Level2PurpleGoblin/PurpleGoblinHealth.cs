using System.Collections;
using UnityEngine;

public class PurpleGoblinHealth : Health
{
    // Coroutine for damage animation
    private IEnumerator damageAnimation;

    // reference for body parts
    private SpriteRenderer bodyParts;

    //reference for TriggerBossFight script
    public TriggerBossFight triggerBossFight;

    //position where to spawn
    private Vector3 spawnPosition;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        m_CurrentHealth = m_maxHp;
        transform.position = spawnPosition;
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
        //Check if the other gameobject contains Pickable and sprite name equals RedBox
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

using System.Collections;
using UnityEngine;

public class PortalHurting : MonoBehaviour
{
    // Coroutine for portal animation
    private IEnumerator portalAnimation;

    // reference to the portal particle system
    private ParticleSystemRenderer portalRenderer;

    // reference for circle collider
    private CircleCollider2D cc2D;

    /// <summary>
    /// MonoBehaviour Awake function
    /// </summary>
    private void Awake()
    {
        portalRenderer = GetComponentInChildren<ParticleSystem>().GetComponent<ParticleSystemRenderer>();
        cc2D = GetComponent<CircleCollider2D>();
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        portalAnimation = PortalIncreaseAnimation();
        StartCoroutine(portalAnimation);
    }

    /// <summary>
    /// Increase portal size
    /// </summary>
    /// <returns></returns>
    public IEnumerator PortalIncreaseAnimation()
    {
        while (portalRenderer.minParticleSize < 0.3f)
        {
            portalRenderer.minParticleSize += 0.01f;
            portalRenderer.maxParticleSize = portalRenderer.minParticleSize;

            cc2D.radius += 0.025f;
            yield return new WaitForSeconds(.1f);
        }

        portalAnimation = PortalDecreaseAnimation();
        StartCoroutine(portalAnimation);
    }

    /// <summary>
    /// Decrease portal size
    /// </summary>
    /// <returns></returns>
    public IEnumerator PortalDecreaseAnimation()
    {
        while (portalRenderer.maxParticleSize > 0)
        {
            portalRenderer.maxParticleSize -= 0.01f;
            portalRenderer.minParticleSize = portalRenderer.maxParticleSize;
            cc2D.radius -= 0.025f;
            yield return new WaitForSeconds(.1f);
        }
        Destroy(gameObject);
    }

    // portal damage amount
    public int m_enemyDamageAmount = 20;

    // portal attacks delay
    public float m_delayBetweenAttacks = 0.5f;

    // check if should apply next dmg to player
    private bool dmg;

    // reference to Coroutine for damaging player
    private IEnumerator damageToPlayer;

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            damageToPlayer = DamageAnimation();
            StartCoroutine(damageToPlayer);
        }
    }

    /// <summary>
    /// Coroutine for damaging player 
    /// </summary>
    /// <returns></returns>
    public IEnumerator DamageAnimation()
    {
        while (true)
        {
            GameController.instance.player.GetComponent<PlayerHealth>().GetDamage(m_enemyDamageAmount, true);
            yield return new WaitForSeconds(m_delayBetweenAttacks);
        }
    }

    /// <summary>
    /// Handle the trigger collision exit between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player 
        if (other.CompareTag("Player"))
        {
            StopCoroutine(damageToPlayer);
        }
    }
}

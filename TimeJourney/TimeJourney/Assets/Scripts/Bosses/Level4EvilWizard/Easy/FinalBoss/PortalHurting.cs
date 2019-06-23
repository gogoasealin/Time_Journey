using System.Collections;
using UnityEngine;

public class PortalHurting : MonoBehaviour
{
    private IEnumerator portalAnimation;
    private ParticleSystemRenderer portalRenderer;
    private CircleCollider2D cc2D;

    private void Awake()
    {
        portalRenderer = GetComponentInChildren<ParticleSystem>().GetComponent<ParticleSystemRenderer>();
        cc2D = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        portalAnimation = PortalIncreaseAnimation();
        StartCoroutine(portalAnimation);
    }

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

    public IEnumerator PortalDecreaseAnimation()
    {
        while (portalRenderer.maxParticleSize > 0)
        {
            portalRenderer.maxParticleSize -= 0.01f;
            portalRenderer.minParticleSize = portalRenderer.maxParticleSize;
            cc2D.radius -= 0.025f;
            yield return new WaitForSeconds(.1f);
        }
        Time.timeScale = 0;

        Destroy(gameObject);
    }

    public int m_enemyDamageAmount = 20;
    public float m_delayBetweenAttacks = 0.5f;
    private bool dmg; // check if should apply next dmg to player

    private IEnumerator damageToPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            damageToPlayer = DamageAnimation();
            StartCoroutine(damageToPlayer);
        }
    }

    public IEnumerator DamageAnimation()
    {
        while (true)
        {
            GameController.instance.player.GetComponent<PlayerHealth>().GetDamage(m_enemyDamageAmount, true);
            yield return new WaitForSeconds(m_delayBetweenAttacks);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(damageToPlayer);
        }
    }
}

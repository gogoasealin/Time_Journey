using System.Collections;
using UnityEngine;

public class EvilWizzardPortal : MonoBehaviour
{
    // Corutine for portal animation
    private IEnumerator portalAnimation;

    // reference to the portal particle system
    private ParticleSystemRenderer portalRenderer;

    // teleport positions 
    public Vector3[] teleportPosition;

    // reference to the gameobject
    public GameObject boss;

    /// <summary>
    /// MonoBehaviour Awake function
    /// </summary>
    private void Awake()
    {
        portalRenderer = GetComponentInChildren<ParticleSystem>().GetComponent<ParticleSystemRenderer>();
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        int random = Random.Range(0, teleportPosition.Length);
        transform.position = teleportPosition[random];
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
            yield return new WaitForSeconds(.1f);
        }
        EnableBoss();
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

            yield return new WaitForSeconds(.1f);
        }
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Disable the portal
    /// </summary>
    public void Disable()
    {
        portalAnimation = PortalDecreaseAnimation();
        StartCoroutine(portalAnimation);
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    public void OnDisable()
    {
        if (boss.GetComponent<Health>().m_CurrentHealth > 0)
        {
            Invoke("Enable", 0.5f);
        }
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Enable the boss
    /// </summary>
    public void EnableBoss()
    {
        boss.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, 0);
        boss.SetActive(true);
    }
}

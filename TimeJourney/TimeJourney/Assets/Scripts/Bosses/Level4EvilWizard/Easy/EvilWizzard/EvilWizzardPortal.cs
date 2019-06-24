using System.Collections;
using UnityEngine;

public class EvilWizzardPortal : MonoBehaviour
{
    private IEnumerator portalAnimation;
    private ParticleSystemRenderer portalRenderer;

    public Vector3[] teleportPosition;

    public GameObject boss;

    private void Awake()
    {
        portalRenderer = GetComponentInChildren<ParticleSystem>().GetComponent<ParticleSystemRenderer>();
    }

    private void OnEnable()
    {
        int random = Random.Range(0, teleportPosition.Length);
        transform.position = teleportPosition[random];
        portalAnimation = PortalIncreaseAnimation();
        StartCoroutine(portalAnimation);
    }

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

    public void Disable()
    {
        portalAnimation = PortalDecreaseAnimation();
        StartCoroutine(portalAnimation);
    }

    public void OnDisable()
    {
        if (boss.GetComponent<Health>().m_CurrentHealth > 0)
        {
            Invoke("Enable", 0.5f);
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void EnableBoss()
    {
        boss.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, 0);
        boss.SetActive(true);
    }
}

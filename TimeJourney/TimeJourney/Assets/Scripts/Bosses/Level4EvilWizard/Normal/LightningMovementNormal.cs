using System.Collections;
using UnityEngine;

public class LightningMovementNormal : MonoBehaviour
{
    [HideInInspector] public Vector3 startPosition;
    public WizardAttack wizardAttack;

    public int m_enemyDamageAmount = 40;
    public float m_delayBetweenAttacks = 0.5f;
    private IEnumerator damageToPlayer;

    private void OnEnable()
    {
        transform.position = startPosition;
        Invoke("Disable", 2f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameController.instance.player.transform.position, 1f * Time.deltaTime);
    }

    private void Disable()
    {
        wizardAttack.StopAttack();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            damageToPlayer = DamageAnimation();
            StartCoroutine(damageToPlayer);
        }
        else if (other.name.Contains("Pickable") && other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("RedBox"))
        {
            gameObject.SetActive(false);
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

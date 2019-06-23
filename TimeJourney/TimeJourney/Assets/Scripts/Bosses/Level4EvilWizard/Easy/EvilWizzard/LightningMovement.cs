using System.Collections;
using UnityEngine;

public class LightningMovement : MonoBehaviour
{
    public Vector3[] position;
    Vector3 goPosition;

    public GameObject boss;
    public int m_enemyDamageAmount = 40;
    public float m_delayBetweenAttacks = 0.5f;

    private IEnumerator damageToPlayer;

    private void OnEnable()
    {
        transform.position = position[Random.Range(0, position.Length)];
        if (transform.position == position[0])
        {
            goPosition = position[1];
        }
        else
        {
            goPosition = position[0];
        }

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, goPosition, 2f * Time.deltaTime);

        if (transform.position == goPosition)
        {
            gameObject.SetActive(false);
        }
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

    void OnDisable()
    {
        boss.GetComponent<EvilWizardHealth>().SetBossColorState(true);

        Invoke("RetreatBoss", 2f);
    }

    void RetreatBoss()
    {
        boss.GetComponent<EvilWizardHealth>().SetBossColorState(false);
        boss.GetComponent<WizardBossRetreat>().enabled = true;
    }
}

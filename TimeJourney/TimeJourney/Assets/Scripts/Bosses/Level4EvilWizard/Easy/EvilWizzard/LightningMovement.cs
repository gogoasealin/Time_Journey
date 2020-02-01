using System.Collections;
using UnityEngine;

public class LightningMovement : MonoBehaviour
{
    // lighting positions
    public Vector3[] position;

    // current target position
    Vector3 goPosition;

    // reference to boss gameobject
    public GameObject boss;

    // damage amount
    public int m_enemyDamageAmount = 40;

    // attack delay
    public float m_delayBetweenAttacks = 0.5f;

    // coroutine for damaging the player
    private IEnumerator damageToPlayer;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
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

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, goPosition, 2f * Time.deltaTime);

        if (transform.position == goPosition)
        {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
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

    /// <summary>
    /// Play animation for receiving damage
    /// </summary>
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

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    void OnDisable()
    {
        boss.GetComponent<EvilWizardHealth>().SetBossColorState(true);

        Invoke("RetreatBoss", 2f);
    }

    /// <summary>
    /// Retreat Boss
    /// </summary>
    void RetreatBoss()
    {
        boss.GetComponent<EvilWizardHealth>().SetBossColorState(false);
        boss.GetComponent<WizardBossRetreat>().enabled = true;
    }
}

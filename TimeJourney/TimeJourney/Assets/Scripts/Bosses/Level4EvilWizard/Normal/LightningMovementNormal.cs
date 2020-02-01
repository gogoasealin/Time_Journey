using System.Collections;
using UnityEngine;

public class LightningMovementNormal : MonoBehaviour
{
    // start position
    [HideInInspector] public Vector3 startPosition;

    // reference to wizardAttack
    public WizardAttack wizardAttack;

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
        transform.position = startPosition;
        Invoke("Disable", 2f);
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameController.instance.player.transform.position, 1f * Time.deltaTime);
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    private void Disable()
    {
        wizardAttack.StopAttack();
        gameObject.SetActive(false);
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
        if (other.CompareTag("Player"))
        {
            StopCoroutine(damageToPlayer);
        }
    }
}

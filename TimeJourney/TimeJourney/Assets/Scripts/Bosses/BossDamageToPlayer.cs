using System.Collections;
using UnityEngine;

public class BossDamageToPlayer : MonoBehaviour
{
    // amount of damage for this enemy
    public int m_enemyDamageAmount = 40;

    // amount of delay between attacks for this enemy
    public float m_delayBetweenAttacks = 0.5f;

    // check if should apply next dmg to player
    private bool dmg;

    //Coroutine for damaging the player
    private IEnumerator damageToPlayer;

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player  
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            damageToPlayer = DamageAnimation();
            StartCoroutine(damageToPlayer);
        }
    }

    /// <summary>
    /// Damage the player
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
    /// Handle the trigger collision enter between this gameobject and another one
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

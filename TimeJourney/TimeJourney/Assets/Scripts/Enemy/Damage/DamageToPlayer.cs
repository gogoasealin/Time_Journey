using System.Collections;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
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
    /// Handle the collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other"> the Gameobject that is colliding with this</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check if the other gameobject has tag Player
        if (other.gameObject.CompareTag("Player"))
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
            //Trigger player damage function
            GameController.instance.player.GetComponent<PlayerHealth>().GetDamage(m_enemyDamageAmount);
            yield return new WaitForSeconds(m_delayBetweenAttacks);
        }
    }

    /// <summary>
    /// Handle the collision exit between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnCollisionExit2D(Collision2D other)
    {
        //Check if the other gameobject has tag Player
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(damageToPlayer);
        }
    }

}


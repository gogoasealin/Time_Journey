using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public int m_enemyDamageAmount = 40;
    public float m_delayBetweenAttacks = 0.5f;
    private bool dmg; // check if should apply next dmg to player

    private IEnumerator damageToPlayer;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            damageToPlayer = DamageAnimation();
            StartCoroutine(damageToPlayer);
        }
    }

    public IEnumerator DamageAnimation()
    {
        while (true)
        {
            GameController.instance.player.GetComponent<PlayerHealth>().GetDamage(m_enemyDamageAmount);
            yield return new WaitForSeconds(m_delayBetweenAttacks);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(damageToPlayer);
        }
    }

}

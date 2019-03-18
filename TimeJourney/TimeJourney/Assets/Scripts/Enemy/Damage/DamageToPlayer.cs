using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public int m_enemyDamageAmount;
    private bool dmg;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!dmg)
            {
                other.gameObject.GetComponent<PlayerHealth>().GetDamage(m_enemyDamageAmount);
                dmg = true;
                Invoke("NextDmg", 1f);
            }
        }
    }

    public void NextDmg()
    {
        dmg = !dmg;
    }
}

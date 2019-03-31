using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public int m_enemyDamageAmount;
    private bool dmg; // check if should apply next dmg to player 
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!dmg)
            {
                other.gameObject.GetComponent<PlayerHealth>().GetDamage(m_enemyDamageAmount);
                dmg = true;
                Invoke("NextDmg", 1f);
                
                //if(other.transform.position.x > transform.position.x)
                //{
                //    other.gameObject.GetComponent<CharacterController2D>().Move(1000f * Time.fixedDeltaTime, false);
                //    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10000f, ForceMode2D.Impulse);
                //}else
                //{
                //    other.gameObject.GetComponent<CharacterController2D>().Move(-1000f * Time.fixedDeltaTime, false);
                //    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10000f, ForceMode2D.Impulse);
                //}
            }
        }
    }

    public void NextDmg()
    {
        dmg = !dmg;
    }
}

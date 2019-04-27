using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToSimplePlayer : MonoBehaviour
{
    public GameObject simplePlayer;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            simplePlayer.GetComponent<SimplePlayerHealth>().GetDamage(1000);
        }
    }
}

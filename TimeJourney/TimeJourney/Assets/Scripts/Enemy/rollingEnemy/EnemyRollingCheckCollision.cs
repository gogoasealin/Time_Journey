using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRollingCheckCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Breakable"))
        {
            Debug.Log("i hit something");
            GetComponent<EnemyRollingHealth>().getDMG = true;
            //invoke not getting dmg and attack again after some seconds;
            Invoke("AttackAgain", 3f);
        }
    }

    private void AttackAgain()
    {
        GetComponent<EnemyRollingHealth>().getDMG = false;
       
    }
}

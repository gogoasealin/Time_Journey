using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollision : MonoBehaviour
{
    public string Type;
    public int ShotDamageAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Collision" + other.name);
        if (other.tag.Equals("BackGround"))
        {
            gameObject.SetActive(false);
            return;
        }

        if(other.tag.Equals("Enemy"))
        {
            other.GetComponent<Health>().GetDamage(Type, ShotDamageAmount);
            gameObject.SetActive(false);
            Debug.Log(other.name);
        }
        if(other.tag.Equals("Breakable"))
        {
            gameObject.SetActive(false);
            Debug.Log("breakable");
        }

    }
}

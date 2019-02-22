using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("BackGround"))
        {
            gameObject.SetActive(false);
            return;
        }

        if(other.tag.Equals("Enemy"))
        {
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

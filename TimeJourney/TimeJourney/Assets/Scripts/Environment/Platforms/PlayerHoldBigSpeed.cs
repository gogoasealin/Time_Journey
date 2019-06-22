using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldBigSpeed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.gameObject.name.Equals("GroundCollider"))
        {
            other.transform.parent.parent.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.gameObject.name.Equals("GroundCollider"))
        {
            other.transform.parent.parent.parent = null;
        }
    }
}

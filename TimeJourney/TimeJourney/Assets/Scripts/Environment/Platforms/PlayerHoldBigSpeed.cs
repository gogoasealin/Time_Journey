using UnityEngine;

public class PlayerHoldBigSpeed : MonoBehaviour
{
    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player    
        if (other.CompareTag("Player") || other.gameObject.name.Equals("GroundCollider"))
        {
            other.transform.parent.parent.SetParent(gameObject.transform);
        }
    }

    /// <summary>
    /// Handle the trigger collision exit between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player    
        if (other.CompareTag("Player") || other.gameObject.name.Equals("GroundCollider"))
        {
            other.transform.parent.parent.parent = null;
        }
    }
}

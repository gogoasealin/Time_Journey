using UnityEngine;

public class ActivateIceByTrigger : MonoBehaviour
{
    /// <summary>
    /// Handle the collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other"> the Gameobject that is colliding with this</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check if the other gameobject has tag Player
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
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
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

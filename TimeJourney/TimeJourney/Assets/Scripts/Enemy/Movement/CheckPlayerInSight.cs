using UnityEngine;

public class CheckPlayerInSight : MonoBehaviour
{
    // reference to enemy movement
    private EnemyMovement em;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        em = GetComponentInParent<EnemyMovement>();
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player  
        if (other.CompareTag("Player"))
        {
            em.PlayerInSight();
        }
    }

    /// <summary>
    /// Handle the trigger collision exit between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        em.PlayerOutOfSight();
    }
}

using UnityEngine;

public class CheckPlayerInSightAI : MonoBehaviour
{
    // reference to enemy ai movement
    private EnemyAIMovement em;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        em = GetComponentInParent<EnemyAIMovement>();
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
            //Debug.Log(other.name);
            em.patrolling = false;
        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    em.PlayerOutOfSight();
    //}
}

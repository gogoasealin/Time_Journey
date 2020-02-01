using UnityEngine;

public class StayInMoveZone : MonoBehaviour
{
    // reference to enemy movement
    public EnemyMovement em;

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player  
        if (other.gameObject.CompareTag("Enemy") && other.gameObject.transform.parent.Equals(transform.parent))
        {
            em.PlayerOutOfSight();
        }
    }
}

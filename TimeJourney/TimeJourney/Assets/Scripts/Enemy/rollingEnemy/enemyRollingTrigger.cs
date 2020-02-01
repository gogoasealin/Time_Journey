using UnityEngine;

public class enemyRollingTrigger : MonoBehaviour
{
    // reference to enemy rolling movement
    private EnemyRollingMovement erm;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        erm = GetComponentInParent<EnemyRollingMovement>();
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player 
        if (other.tag.Equals("Player"))
        {
            //set rotation;
            erm.SetRotation(true);

            // select direction
            if (gameObject.transform.position.x > other.transform.position.x)
            {
                erm.Roll = erm.RollLeft;
            }
            else
            {
                erm.Roll = erm.RollRight;
            }
            erm.roll = true;
        }
    }
}

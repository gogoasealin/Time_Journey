using UnityEngine;

public class enemyRollingTrigger : MonoBehaviour
{
    private EnemyRollingMovement erm;

    private void Start()
    {
        erm = GetComponentInParent<EnemyRollingMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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

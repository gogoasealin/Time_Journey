using UnityEngine;

public class CheckPlayerInSightAI : MonoBehaviour
{
    private EnemyAIMovement em;

    private void Start()
    {
        em = GetComponentInParent<EnemyAIMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            em.patrolling = false;
        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    em.PlayerOutOfSight();
    //}
}

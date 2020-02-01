using UnityEngine;

public class EnemyAIMovementStarter : MonoBehaviour
{
    /// <summary>
    /// MonoBehaviour OnBecameVisible function
    /// </summary>
    private void OnBecameVisible()
    {
        //check if we already send a stop moving request
        //if so stop it 
        CancelInvoke("DisableAi");

        GetComponentInParent<EnemyAIMovement>().enabled = true;
    }

    /// <summary>
    /// MonoBehaviour OnBecameInvisible function
    /// </summary>
    private void OnBecameInvisible()
    {
        Invoke("DisableAi", 10f);
    }

    /// <summary>
    /// Disable AI movement
    /// </summary>
    void DisableAi()
    {
        GetComponentInParent<EnemyAIMovement>().enabled = false;
    }
}

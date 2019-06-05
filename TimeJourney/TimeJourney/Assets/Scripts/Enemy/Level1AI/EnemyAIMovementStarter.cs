using UnityEngine;

public class EnemyAIMovementStarter : MonoBehaviour
{

    private void OnBecameVisible()
    {
        //check if we already send a stop moving request
        //if so stop it 
        CancelInvoke("DisableAi");

        GetComponentInParent<EnemyAIMovement>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        Invoke("DisableAi", 10f);
    }

    void DisableAi()
    {
        GetComponentInParent<EnemyAIMovement>().enabled = false;
    }
}

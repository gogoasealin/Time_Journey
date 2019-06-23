using UnityEngine;

public class ShotFreeze : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "BossPlayer")
        {
            other.GetComponent<FinalBossMovementV2>().Freeze();
            gameObject.SetActive(false);
        }
    }
}

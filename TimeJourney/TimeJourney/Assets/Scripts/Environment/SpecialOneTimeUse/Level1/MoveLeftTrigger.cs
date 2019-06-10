using UnityEngine;

public class MoveLeftTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerMovement>() != null)
        {
            other.GetComponent<PlayerMovement>().canMoveLeft = true;
            Destroy(gameObject);
        }
    }
}

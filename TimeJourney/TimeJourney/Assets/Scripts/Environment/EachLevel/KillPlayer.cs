using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameController.instance.GameOver();
        }
        if (other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player    
        if (other.tag == "Player")
        {
            GameController.instance.GameOver();
        }

        //Check if the other gameobject has tag Enemy    
        if (other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }
    }
}

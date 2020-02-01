using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player   
        if (other.CompareTag("Player"))
        {
            // call save game
            GameController.instance.SaveGame();
            // destroy current object
            Destroy(gameObject);
        }
    }
}

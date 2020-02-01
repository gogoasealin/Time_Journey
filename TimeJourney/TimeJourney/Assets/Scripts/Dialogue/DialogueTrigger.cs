using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    //reference to dialog
    Dialog dialog;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        dialog = GetComponent<Dialog>();
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other is BoxCollider2D)
        {
            //Check if the other gameobject has tag Player  
            if (other.CompareTag("Player") && dialog != null)
            {
                dialog.enabled = true;
            }
        }
    }

    /// <summary>
    /// Handle the trigger collision exit between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other is BoxCollider2D)
        {
            //Check if the other gameobject has tag Player  
            if (other.CompareTag("Player") && dialog != null)
            {
                dialog.CheckDialogStatus();
            }
        }
    }
}

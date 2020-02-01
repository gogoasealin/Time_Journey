using UnityEngine;

public class DialogWithActionTrigger : MonoBehaviour
{
    //reference to dialog with action
    DialogWithAction dialog;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        dialog = GetComponent<DialogWithAction>();
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
                dialog.dialogEnded = false;
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

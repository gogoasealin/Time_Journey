using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    Dialog dialog;

    private void Start()
    {
        dialog = GetComponent<Dialog>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other is BoxCollider2D)
        {
            if (other.CompareTag("Player") && dialog != null)
            {
                dialog.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other is BoxCollider2D)
        {
            if (other.CompareTag("Player") && dialog != null)
            {
                dialog.CheckDialogStatus();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogWithActionTrigger : MonoBehaviour
{
    DialogWithAction dialog;

    private void Start()
    {
        dialog = GetComponent<DialogWithAction>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && dialog != null)
        {
            dialog.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && dialog != null)
        {
            dialog.EndDialog();
        }
    }
}

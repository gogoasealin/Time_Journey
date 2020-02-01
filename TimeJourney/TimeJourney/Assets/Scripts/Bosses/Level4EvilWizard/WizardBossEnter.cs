using UnityEngine;

public class WizardBossEnter : MonoBehaviour
{
    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        // update the local scale
        transform.localScale += new Vector3(0.01f, 0.01f, 0);
        if (transform.localScale.x >= 1f)
        {
            transform.localScale = new Vector3(1f, 1f, 0);
            GetComponent<EvilWizardMovementStage1>().Attack();
            enabled = false;
        }
    }
}

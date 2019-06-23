using UnityEngine;

public class EvilWizardMovementStage1 : MonoBehaviour
{
    public GameObject wizzardPortal;
    public GameObject lightning;

    private void OnEnable()
    {
        transform.localScale = new Vector3(0.03f, 0.03f, 0);
        GetComponent<WizardBossEnter>().enabled = true;
    }

    public void Attack()
    {
        lightning.SetActive(true);
    }
}

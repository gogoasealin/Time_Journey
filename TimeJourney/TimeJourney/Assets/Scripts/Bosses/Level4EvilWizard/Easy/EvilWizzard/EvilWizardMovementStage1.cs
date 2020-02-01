using UnityEngine;

public class EvilWizardMovementStage1 : MonoBehaviour
{
    // reference to wizzardPortal
    public GameObject wizzardPortal;

    // reference to lightning object
    public GameObject lightning;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        transform.localScale = new Vector3(0.03f, 0.03f, 0);
        GetComponent<WizardBossEnter>().enabled = true;
    }

    /// <summary>
    /// Call evilwizard Attack
    /// </summary>
    public void Attack()
    {
        lightning.SetActive(true);
    }
}

using UnityEngine;

public class WizardBossRetreat : MonoBehaviour
{
    // reference to the portal
    public GameObject portal;

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        //updated local scale
        transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        if (transform.localScale.x <= 0.3f)
        {
            portal.GetComponent<EvilWizzardPortal>().Disable();
            gameObject.SetActive(false);
            enabled = false;
        }
    }
}

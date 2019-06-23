using UnityEngine;

public class WizardBossRetreat : MonoBehaviour
{
    public GameObject portal;

    private void Update()
    {
        transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        if (transform.localScale.x <= 0.3f)
        {
            portal.GetComponent<EvilWizzardPortal>().Disable();
            gameObject.SetActive(false);
            enabled = false;
        }
    }
}

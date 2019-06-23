using System.Collections;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{

    public GameObject lightning;
    private IEnumerator lightningAttack;


    void Start()
    {
        Invoke("InitiateAttack", 5f);
    }

    public void InitiateAttack()
    {
        GetComponent<WizardMovement>().attack = true;
        GetComponent<EvilWizardNormalHealth>().SetBossColorState(true);
        lightning.GetComponent<LightningMovementNormal>().startPosition = GameController.instance.player.transform.position;
        Invoke("LaunchAttack", 2f);
    }

    public void LaunchAttack()
    {
        lightning.SetActive(true);
    }

    public void StopAttack()
    {
        GetComponent<EvilWizardNormalHealth>().SetBossColorState(false);
        GetComponent<WizardMovement>().attack = false;
        if (GetComponent<EvilWizardNormalHealth>().m_CurrentHealth > 0)
        {
            Invoke("InitiateAttack", 5f);
        }
    }

    private void OnDisable()
    {
        CancelInvoke("InitiateAttack");
        CancelInvoke("LaunchAttack");
    }
}

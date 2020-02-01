using System.Collections;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    // reference to lightning object
    public GameObject lightning;

    // Coroutine for lighting attack
    private IEnumerator lightningAttack;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        Invoke("InitiateAttack", 5f);
    }

    /// <summary>
    /// Initiate attack
    /// </summary>
    public void InitiateAttack()
    {
        GetComponent<WizardMovement>().attack = true;
        GetComponent<EvilWizardNormalHealth>().SetBossColorState(true);
        lightning.GetComponent<LightningMovementNormal>().startPosition = GameController.instance.player.transform.position;
        Invoke("LaunchAttack", 2f);
    }

    /// <summary>
    /// Trigger attack
    /// </summary>
    public void LaunchAttack()
    {
        lightning.SetActive(true);
    }

    /// <summary>
    /// Stop attack
    /// </summary>
    public void StopAttack()
    {
        GetComponent<EvilWizardNormalHealth>().SetBossColorState(false);
        GetComponent<WizardMovement>().attack = false;
        if (GetComponent<EvilWizardNormalHealth>().m_CurrentHealth > 0)
        {
            Invoke("InitiateAttack", 5f);
        }
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    private void OnDisable()
    {
        CancelInvoke("InitiateAttack");
        CancelInvoke("LaunchAttack");
    }
}

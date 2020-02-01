using UnityEngine;

public class TriggerBossFightWizardNormal : MonoBehaviour
{
    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        // set special action
        GameController.instance.SpecialAction = GetComponent<SpecialAction>().DoSpecialAction;
    }
}

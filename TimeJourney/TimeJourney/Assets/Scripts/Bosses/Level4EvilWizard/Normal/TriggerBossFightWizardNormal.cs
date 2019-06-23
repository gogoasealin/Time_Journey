using UnityEngine;

public class TriggerBossFightWizardNormal : MonoBehaviour
{
    private void Start()
    {
        GameController.instance.SpecialAction = GetComponent<SpecialAction>().DoSpecialAction;
    }
}

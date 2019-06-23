using UnityEngine;

public class LightningMovementNormal : MonoBehaviour
{
    [HideInInspector] public Vector3 startPosition;
    public WizardAttack wizardAttack;

    private void OnEnable()
    {
        transform.position = startPosition;
        Invoke("Disable", 2f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameController.instance.player.transform.position, 1f * Time.deltaTime);
    }

    private void Disable()
    {
        wizardAttack.StopAttack();
        gameObject.SetActive(false);
    }

}

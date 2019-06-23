using UnityEngine;

public class TriggerBossFightWizard : MonoBehaviour
{
    public GameObject bossWalls;
    public GameObject portal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bossWalls.SetActive(true);
            GameController.instance.SpecialAction = GetComponent<SpecialAction>().DoSpecialAction;
            portal.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void Revert()
    {
        bossWalls.SetActive(false);
    }
}

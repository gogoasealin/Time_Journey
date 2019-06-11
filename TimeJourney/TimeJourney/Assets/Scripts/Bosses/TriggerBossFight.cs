using UnityEngine;

public class TriggerBossFight : MonoBehaviour
{
    public GameObject bossWalls;
    public GameObject boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bossWalls.SetActive(true);
            GameController.instance.SpecialAction = GetComponent<SpecialAction>().DoSpecialAction;
            boss.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void Revert()
    {
        bossWalls.SetActive(false);
        boss.SetActive(false);
    }


}

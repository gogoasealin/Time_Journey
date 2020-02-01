using UnityEngine;

public class TriggerBossFightWizard : MonoBehaviour
{
    // reference to the boss walls object
    public GameObject bossWalls;

    // referencce to the portal
    public GameObject portal;

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player
        if (other.CompareTag("Player"))
        {
            bossWalls.SetActive(true);
            GameController.instance.SpecialAction = GetComponent<SpecialAction>().DoSpecialAction;
            portal.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Revert the trigger
    /// </summary>
    public void Revert()
    {
        bossWalls.SetActive(false);
    }
}

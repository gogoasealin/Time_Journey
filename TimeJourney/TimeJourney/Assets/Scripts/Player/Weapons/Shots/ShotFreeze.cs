using UnityEngine;

public class ShotFreeze : MonoBehaviour
{
    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has BossPlayer
        if (other.gameObject.name == "BossPlayer")
        {
            other.GetComponent<FinalBossMovementV2>().Freeze();
            //disable gameobject
            gameObject.SetActive(false);
        }
    }
}

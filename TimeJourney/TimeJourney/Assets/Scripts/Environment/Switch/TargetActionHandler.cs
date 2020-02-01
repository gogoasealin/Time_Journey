using UnityEngine;

public class TargetActionHandler : MonoBehaviour
{
    // reference to object to be moved
    public GameObject objectToMove;

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Shot 
        if (other.tag.Equals("Shot"))
        {
            objectToMove.SetActive(true);
            Destroy(gameObject);
        }
    }
}

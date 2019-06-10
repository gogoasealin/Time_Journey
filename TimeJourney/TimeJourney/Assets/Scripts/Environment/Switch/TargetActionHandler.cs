using UnityEngine;

public class TargetActionHandler : MonoBehaviour
{
    public GameObject objectToMove;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Shot"))
        {
            objectToMove.SetActive(true);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class MoveOnTrigger : MonoBehaviour
{
    // move speed
    public float moveSpeed;

    // next position 
    public Vector3 nextPosition;

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * moveSpeed);
        if (gameObject.transform.position == nextPosition)
        {
            Destroy(GetComponent<MoveOnTrigger>());
        }
    }
}

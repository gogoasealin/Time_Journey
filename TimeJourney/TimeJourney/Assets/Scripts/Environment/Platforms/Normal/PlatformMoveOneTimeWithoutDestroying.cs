using UnityEngine;

public class PlatformMoveOneTimeWithoutDestroying : MonoBehaviour
{
    public Vector3 nextPosition;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * 2);
        if (transform.position == nextPosition)
        {
            Destroy(this);
        }
    }
}

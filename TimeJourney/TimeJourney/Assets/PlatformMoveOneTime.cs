using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveOneTime : MonoBehaviour
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

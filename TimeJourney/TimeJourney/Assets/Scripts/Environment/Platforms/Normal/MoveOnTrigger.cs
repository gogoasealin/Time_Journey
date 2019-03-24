using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTrigger : MonoBehaviour
{
    public float moveSpeed;

    public Vector3 nextPosition;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * moveSpeed);
        if (gameObject.transform.position == nextPosition)
        {
            Destroy(GetComponent<MoveOnTrigger>());
        }
    }
}

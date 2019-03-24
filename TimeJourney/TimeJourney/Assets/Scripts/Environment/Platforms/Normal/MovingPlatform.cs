using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float m_moveSpeed;

    private Vector3 startPosition;
    public Vector3 nextPosition;
    private Vector3 goPosition;

    void Start()
    {
        startPosition = transform.position;
        goPosition = nextPosition;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goPosition, Time.deltaTime * m_moveSpeed);
        if (transform.position == goPosition)
        {
            if (transform.position == startPosition)
            {
                goPosition = nextPosition;
            }
            else
            {
                goPosition = startPosition;
            }
        }
    }
}

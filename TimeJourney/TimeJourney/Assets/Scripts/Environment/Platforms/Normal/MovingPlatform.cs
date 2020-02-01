using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // move speed
    public float m_moveSpeed;

    // start position
    private Vector3 startPosition;

    //next position
    public Vector3 nextPosition;

    // go position
    private Vector3 goPosition;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        startPosition = transform.position;
        goPosition = nextPosition;
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
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

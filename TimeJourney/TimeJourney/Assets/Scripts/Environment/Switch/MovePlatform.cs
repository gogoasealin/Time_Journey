using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    // move speed
    public float m_moveSpeed;

    // Go to next position status
    public bool m_GoToNextPosition;

    // next position
    public Vector3 nextPosition;

    // start position
    private Vector3 startPosition;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        startPosition = transform.position;
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        if (m_GoToNextPosition)
        {
            MoveToPosition(nextPosition);
        }
        else
        {
            MoveToPosition(startPosition);
        }
    }

    /// <summary>
    /// Move to Position
    /// </summary>
    /// <param name="goPosition"></param>
    public void MoveToPosition(Vector3 goPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, goPosition, Time.deltaTime * m_moveSpeed);
        if (Vector3.Distance(transform.position, goPosition) <= 0)
        {
            GetComponent<MovePlatform>().enabled = false;
        }
    }

}

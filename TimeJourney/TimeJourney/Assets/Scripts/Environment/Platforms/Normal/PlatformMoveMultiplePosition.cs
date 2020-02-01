using UnityEngine;

public class PlatformMoveMultiplePosition : MonoBehaviour
{
    // move speed
    public float m_moveSpeed = 1;

    //all positions
    public Vector3[] m_Positions;

    // go position
    private Vector3 goPosition;

    //current position
    private int currentPosition;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        currentPosition = 0;
        goPosition = m_Positions[currentPosition];
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goPosition, Time.deltaTime * m_moveSpeed);
        if (transform.position == goPosition)
        {
            currentPosition++;
            if (currentPosition >= m_Positions.Length)
            {
                currentPosition = 0;
            }
            goPosition = m_Positions[currentPosition];
        }
    }
}

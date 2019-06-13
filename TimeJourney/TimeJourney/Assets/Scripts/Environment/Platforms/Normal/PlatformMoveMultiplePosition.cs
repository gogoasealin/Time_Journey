using UnityEngine;

public class PlatformMoveMultiplePosition : MonoBehaviour
{
    public float m_moveSpeed = 1;
    public Vector3[] m_Positions;

    private Vector3 goPosition;
    private int currentPosition;

    void Start()
    {
        currentPosition = 0;
        goPosition = m_Positions[currentPosition];
    }

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

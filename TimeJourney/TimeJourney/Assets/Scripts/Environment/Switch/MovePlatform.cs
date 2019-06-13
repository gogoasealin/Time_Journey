using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    public float m_moveSpeed;
    public bool m_GoToNextPosition;
    public Vector3 nextPosition;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

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


    public void MoveToPosition(Vector3 goPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, goPosition, Time.deltaTime * m_moveSpeed);
        if (Vector3.Distance(transform.position, goPosition) <= 0)
        {
            GetComponent<MovePlatform>().enabled = false;
        }
    }

}

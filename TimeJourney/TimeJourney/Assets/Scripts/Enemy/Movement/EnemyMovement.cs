using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool m_playerInSight;
    public bool m_playerInRange;

    public float[] m_patrolPosition;
    private int nextPosition;

    public Vector3 m_playerLastPosition;
    public Transform m_playerBodyCollider;
    public float movementSpeed;
    public bool m_checkLastPosition; // say if checked last player position;

    private void Start()
    {
        m_playerBodyCollider = GameController.instance.player.transform.GetChild(5).GetChild(0).transform;
    }

    private void Update()
    {
        if (!m_playerInSight)
        {
            Patrol();
        }
        else
        {
            ChasePlayer();
        }
    }

    protected virtual void Patrol()
    {
        if (CalculateDistance())
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(m_patrolPosition[nextPosition], transform.localPosition.y), movementSpeed * Time.deltaTime);
        }
        else
        {
            nextPosition++;
            if(nextPosition >= m_patrolPosition.Length)
            {
                nextPosition = 0;
            }
        }
    }

    protected virtual bool CalculateDistance()
    {
        if (transform.localPosition.x == m_patrolPosition[nextPosition])
        {
            return false;
        }
        return true;
    }

    protected virtual void ChasePlayer()
    {
        if (m_playerInRange)
        {
            Attack();
        }
        else if(m_playerInSight && !m_checkLastPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(m_playerBodyCollider.position.x, transform.position.y), movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(m_playerLastPosition.x, transform.position.y), movementSpeed * Time.deltaTime);
            if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(m_playerLastPosition.x)) < 0.1f)
            {
                m_checkLastPosition = true;
                m_playerInSight = false;
            }
        }
    }

    protected virtual void Attack()
    {
        //
    }
}

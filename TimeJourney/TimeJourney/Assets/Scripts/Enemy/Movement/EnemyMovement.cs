using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool m_playerInSight;
    public bool m_playerInRange;

    public float[] m_patrolPosition;
    private int nextPosition;

    public Vector3 m_playerPosition;
    public float movementSpeed;

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
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(m_playerPosition.x, transform.position.y), movementSpeed * Time.deltaTime);
            if (transform.position.x == m_playerPosition.x)
            {
                m_playerPosition = GameController.instance.player.transform.position;
            }
        }
    }

    protected virtual void Attack()
    {
        //
    }
}

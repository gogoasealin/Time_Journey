using UnityEngine;

public class EnemyNormalMovement : EnemyMovement
{

    public float[] m_patrolPosition;

    [SerializeField] private int nextPosition;
    private Vector3 m_playerLastPosition;
    private Transform m_playerBodyCollider;
    private bool m_checkLastPosition; // say if checked last player position;
    public bool m_FacingRight;  // direction currently facing.

    private bool enterStateChase;
    private bool enterStatePatrol;


    private void Start()
    {
        m_playerBodyCollider = GameController.instance.player.transform.GetChild(5).GetChild(0).transform;
        if (GetComponentInChildren<ParticleSystemRenderer>().flip.x == 0)
        {
            m_FacingRight = false;
        }
        else
        {
            m_FacingRight = true;
        }
        CheckPatrolFlip();
        enterStatePatrol = true;
        enterStateChase = false;
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

    protected override void Patrol()
    {
        if (enterStatePatrol)
        {
            CheckPatrolFlip();
            enterStatePatrol = false;
            enterStateChase = true;
        }
        if (CalculateDistance())
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(m_patrolPosition[nextPosition], transform.localPosition.y), m_movementSpeed * Time.deltaTime);
        }
        else
        {
            nextPosition++;
            if (nextPosition >= m_patrolPosition.Length)
            {
                nextPosition = 0;
            }
            CheckPatrolFlip();
        }
    }

    protected virtual void CheckPatrolFlip()
    {
        if (transform.localPosition.x > m_patrolPosition[nextPosition] && m_FacingRight)
        {
            Flip();
        }
        else if (transform.localPosition.x < m_patrolPosition[nextPosition] && !m_FacingRight)
        {
            Flip();
        }
    }

    protected override void ChasePlayer()
    {
        if (enterStateChase)
        {
            CheckChasingFlip();
            enterStateChase = false;
            enterStatePatrol = true;
        }
        if (m_playerInSight && !m_checkLastPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(m_playerBodyCollider.position.x, transform.position.y), m_movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(m_playerLastPosition.x, transform.position.y), m_movementSpeed * Time.deltaTime);
            if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(m_playerLastPosition.x)) < 0.1f)
            {
                m_checkLastPosition = true;
                m_playerInSight = false;
                CheckChasingFlip();
            }
        }
    }

    protected virtual void CheckChasingFlip()
    {
        if (transform.position.x > m_playerBodyCollider.position.x && m_FacingRight)
        {
            Flip();
        }
        else if (transform.position.x < m_playerBodyCollider.position.x && !m_FacingRight)
        {
            Flip();
        }
    }

    protected override void Flip()
    {
        if (m_FacingRight)
        {
            GetComponentInChildren<ParticleSystemRenderer>().flip = Vector3.zero;
        }
        else
        {
            GetComponentInChildren<ParticleSystemRenderer>().flip = new Vector3(180f, 0, 0);
        }
        m_FacingRight = !m_FacingRight;
    }

    protected virtual bool CalculateDistance()
    {
        if (transform.localPosition.x == m_patrolPosition[nextPosition])
        {
            return false;
        }
        return true;
    }



    public override void PlayerInSight()
    {
        m_checkLastPosition = false;
        m_playerInSight = true;
    }

    public override void PlayerOutOfSight()
    {
        m_playerInSight = false;
        m_playerLastPosition = m_playerBodyCollider.position;
    }
}

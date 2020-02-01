using UnityEngine;

public class EnemyNormalMovement : EnemyMovement
{
    // patrol position
    public float[] m_patrolPosition;

    // next position
    [SerializeField] private int nextPosition;

    // last position
    private Vector3 m_playerLastPosition;

    // reference to player body collider
    private Transform m_playerBodyCollider;

    // say if checked last player position;
    private bool m_checkLastPosition;

    // direction currently facing.
    public bool m_FacingRight;

    // chase state
    private bool enterStateChase;

    // patrol state
    private bool enterStatePatrol;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
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

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
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

    /// <summary>
    /// Patrol 
    /// </summary>
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

    /// <summary>
    /// Flip patrol
    /// </summary>
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

    /// <summary>
    /// Chase
    /// </summary>
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

    /// <summary>
    /// Flip check when chasing
    /// </summary>
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

    /// <summary>
    /// Flip
    /// </summary>
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

    /// <summary>
    /// Calculate distance
    /// </summary>
    /// <returns></returns>
    protected virtual bool CalculateDistance()
    {
        if (transform.localPosition.x == m_patrolPosition[nextPosition])
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Check if player is in sight
    /// </summary>
    public override void PlayerInSight()
    {
        m_checkLastPosition = false;
        m_playerInSight = true;
    }

    /// <summary>
    /// Check if player is out of sight
    /// </summary>
    public override void PlayerOutOfSight()
    {
        m_playerInSight = false;
        m_playerLastPosition = m_playerBodyCollider.position;
    }
}

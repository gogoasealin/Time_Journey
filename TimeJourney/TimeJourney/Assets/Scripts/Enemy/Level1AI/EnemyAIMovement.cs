using Pathfinding;
using UnityEngine;

public class EnemyAIMovement : MonoBehaviour
{
    [Tooltip("Player AttackPosition(center of the player)")]
    public Transform playerAttackPosition;
    public Transform enemyGFX;
    public Vector3[] patrollingPositions;
    private int nextPosition;

    public bool patrolling;
    public float speed = 400f;
    public float nextWaypointDistance = 1f;

    Path path;
    int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        nextPosition = 0;
    }

    public void OnEnable()
    {
        InvokeRepeating("UpdatePath", 0, .5f);
        patrolling = true;
    }

    public void OnDisable()
    {
        CancelInvoke("UpdatePath");
    }


    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            if (patrolling)
            {
                seeker.StartPath(rb.position, patrollingPositions[nextPosition], OnPathComplete);
            }
            else
            {
                seeker.StartPath(rb.position, playerAttackPosition.position, OnPathComplete);
            }
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {

            reachedEndOfPath = true;
            nextPosition++;
            if (nextPosition >= patrollingPositions.Length)
            {
                nextPosition = 0;
            }
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Move();
    }

    public void Move()
    {
        Vector2 direction = ((Vector2)path.vectorPath[path.vectorPath.Count - 1] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //right
        if (force.x >= 0.5f)
        {
            GetComponentInChildren<ParticleSystemRenderer>().flip = new Vector3(180f, 0, 0);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (force.x <= -0.5f) //left
        {
            GetComponentInChildren<ParticleSystemRenderer>().flip = Vector3.zero;
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);

        }
    }
}

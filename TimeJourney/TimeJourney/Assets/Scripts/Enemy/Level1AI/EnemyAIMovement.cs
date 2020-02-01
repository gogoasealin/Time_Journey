using Pathfinding;
using UnityEngine;

public class EnemyAIMovement : MonoBehaviour
{
    [Tooltip("Player AttackPosition(center of the player)")]
    // reference to player attack position
    public Transform playerAttackPosition;

    //
    public Vector3[] patrollingPositions;

    // next Position
    private int nextPosition;

    // patrolling status
    public bool patrolling;

    // movement speed
    public float speed = 400f;

    // distance between next waypoint
    public float nextWaypointDistance = 1f;

    //path reference
    Path path;

    //starting waypoint
    int currentWaypoint = 0;

    // reach end of path status
    public bool reachedEndOfPath = false;

    //seeker referencce
    Seeker seeker;

    //current rigidbody reference
    Rigidbody2D rb;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        nextPosition = 0;
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    public void OnEnable()
    {
        InvokeRepeating("UpdatePath", 0, .5f);
        patrolling = true;
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    public void OnDisable()
    {
        CancelInvoke("UpdatePath");
    }

    /// <summary>
    /// Update the path
    /// </summary>
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

    /// <summary>
    /// When the end of path is reached
    /// </summary>
    /// <param name="p"></param>
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    /// <summary>
    /// MonoBehaviour FixedUpdated function called every fixed frame-rate frame
    /// </summary>
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

    /// <summary>
    /// Handle Move 
    /// </summary>
    public void Move()
    {
        Vector2 direction = ((Vector2) path.vectorPath[path.vectorPath.Count - 1] - rb.position).normalized;
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

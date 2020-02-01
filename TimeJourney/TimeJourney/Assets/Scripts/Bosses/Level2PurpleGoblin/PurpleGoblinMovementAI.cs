using Pathfinding;
using UnityEngine;

public class PurpleGoblinMovementAI : MonoBehaviour
{
    [Tooltip("Player ShotPosition(center of the player)")]
    // reference to player shot position
    public Transform playerShotPosition;

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

    // reference for the GFX transform
    private Transform enemyGFX;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyGFX = transform.GetChild(0);
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    public void OnEnable()
    {
        InvokeRepeating("UpdatePath", 0, .5f);
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
            seeker.StartPath(rb.position, playerShotPosition.position, OnPathComplete);
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
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //right
        if (transform.position.x <= playerShotPosition.position.x)
        {
            enemyGFX.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x >= playerShotPosition.position.x) //left
        {
            enemyGFX.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

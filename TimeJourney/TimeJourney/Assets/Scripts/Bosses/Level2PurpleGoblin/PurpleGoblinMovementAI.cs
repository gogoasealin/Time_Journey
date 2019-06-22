using Pathfinding;
using UnityEngine;

public class PurpleGoblinMovementAI : MonoBehaviour
{
    [Tooltip("Player ShotPosition(center of the player)")]
    public Transform playerShotPosition;

    public float speed = 400f;
    public float nextWaypointDistance = 1f;

    Path path;
    int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private Transform enemyGFX;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyGFX = transform.GetChild(0);
    }

    public void OnEnable()
    {
        InvokeRepeating("UpdatePath", 0, .5f);
    }

    public void OnDisable()
    {
        CancelInvoke("UpdatePath");
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, playerShotPosition.position, OnPathComplete);
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
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
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

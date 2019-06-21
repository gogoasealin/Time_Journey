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

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
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
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (force.x <= -0.5f) //left
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);

        }
    }
}

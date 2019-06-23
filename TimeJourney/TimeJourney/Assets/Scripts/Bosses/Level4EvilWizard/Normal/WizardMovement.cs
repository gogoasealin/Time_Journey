using Pathfinding;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    [Tooltip("Player ShotPosition(center of the player)")]
    public Transform playerShotPosition;

    public float speed = 400f;
    public float nextWaypointDistance = 1f;
    public float localScale = 1f;

    Path path;
    int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public bool attack;

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
        if (attack)
        {
            return;
        }
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
            transform.localScale = new Vector3(-localScale, localScale, 0);
        }
        else if (transform.position.x >= playerShotPosition.position.x) //left
        {
            transform.localScale = new Vector3(localScale, localScale, 0);
        }
    }
}

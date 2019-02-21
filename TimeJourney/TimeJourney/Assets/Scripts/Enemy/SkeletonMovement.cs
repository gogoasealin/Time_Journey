using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour {

    //movement
    public Animator anim;
    public Vector2[] patrolingPosition; // all patrolling position
    public Vector3 movingToPosition; // position where currently moving
    public float moveSpeed;
    public float patrolSpeed;
    public float chasingSpeed;
    private int nextPosition; // next position id
    [Tooltip("first direction where enemy is going (true = right, false = left)")]
    [SerializeField] private bool facingRight;
    public bool animating; // check if enemy should move or should play an special animation (other than moving)
    public BoxCollider2D boxColl;
    [SerializeField] private bool reachedPosition; // check if we reach current movingPosition


    //search Player
    [SerializeField] private bool playerFound; // if enemy found the player
    private bool playerInTrigger; // if player is in trigger
    [SerializeField] private Vector3 lastKnowPosition; // last position where player was seen

    // checkGround
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    // player
    public GameObject player;

    void Start () {
        nextPosition = 0;
        lastKnowPosition = Vector3.zero;
        if (patrolingPosition.Length > 0 )
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("idle", true);
        }
    }
	
	void Update () {
        if (!CheckPlayer() && !animating)
        {
            if (reachedPosition) {
                Patrol();
                //Debug.Log("patroling");
            }
            else
            {
                SearchLastKnowPosition();
                //Debug.Log("searching");
            }
        }
        else if (CheckPlayer() && CheckGround() && !animating)
        {
            FollowPlayer();
            // Debug.Log("folowing");
        }
        //else 
        //{
        //    Debug.Log("Wierd Behaviour");
        //}
    }

    private bool CheckGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down,1f, groundLayer))
        {
            return true; 
        }
        return false;
    }

    private bool CheckPlayer()
    {
        if (facingRight)
        {
            //Debug.DrawRay(transform.position, Vector2.right * 1.5f, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, playerLayer);
            if (hit.collider != null)
            {
                return PlayerFound(hit.transform.position);
            }
        }
        else
        {
            //Debug.DrawRay(transform.position, Vector2.left * 1.5, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, playerLayer);
            if (hit.collider != null)
            {
                return PlayerFound(hit.transform.position);
            }
        }
        anim.SetBool("playerFound", false);
        moveSpeed = chasingSpeed;
        return false;
    }

    bool PlayerFound(Vector3 playerPos)
    {
        anim.SetBool("playerFound", true);
        moveSpeed = chasingSpeed;
        reachedPosition = false;
        lastKnowPosition = playerPos;
        return true;
    }

    void SearchLastKnowPosition()
    {
        if (lastKnowPosition != Vector3.zero && CheckGround())
        {
            GoToPosition(lastKnowPosition);
            if (Mathf.Abs(transform.position.x - lastKnowPosition.x) < 0.05f)
            {
                lastKnowPosition = Vector3.zero;
                reachedPosition = true;
            }
        }
        else
        {
            reachedPosition = true;
        }
    }

    private void Flip(int right = 0)
    {
        facingRight = !facingRight;
        if(right == 1)
        {
            if(transform.eulerAngles.y == 180)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            facingRight = true;
            // Nu face facing bine + cautarea playerului
        }
        else if (right == 2)
        {
            if (transform.eulerAngles.y == 0)
            {
                transform.Rotate(0f, -180f, 0f);
            }
            facingRight = false;
        }

    }

    private void Patrol()
    {
        movingToPosition.x = patrolingPosition[nextPosition].x;
        movingToPosition.y = transform.position.y;
        GoToPosition(movingToPosition);
        if (transform.position.x == movingToPosition.x)
        {
            if (patrolingPosition.Length > 0) {
                nextPosition++; 
                if(nextPosition == patrolingPosition.Length)
                {
                    nextPosition = 0;
                }
            }
        }
    }

    private void GoToPosition(Vector3 movingPosition)
    {
        CheckFacing();
        transform.position = Vector2.MoveTowards(transform.position, movingPosition, Time.deltaTime * moveSpeed);

    }

    private void CheckFacing()
    {
        if (transform.position.x > movingToPosition.x)
        {
            if (facingRight)
            {
                Flip(2);
            }
        }
        else
        {
            if (!facingRight)
            {
                Flip(1);
            }
        }
    }

    private void FollowPlayer()
    {
        movingToPosition.x = player.transform.position.x;
        movingToPosition.y = transform.position.y;
        GoToPosition(movingToPosition);
    }

    public void StartAnimating()
    {
        animating = true;
    }

    public void StopDmg()
    {
        anim.SetBool("dmg", false);
        animating = false;
    }

    public void StopAttack()
    {
        anim.SetBool("attack", false);
        animating = false;
    }

    public void Die()
    {
        boxColl.size = new Vector2(0.01f, 0.01f);
        animating = true;
    }

    public void StopDie()
    {
        animating = false;
        gameObject.SetActive(false);
    }

}

using UnityEngine;

public class GoblinBossAttack : MonoBehaviour
{
    // reference to parent transform
    Transform parent;
    // reference to the animator
    public Animator anim;

    // attack status
    [SerializeField] private bool attack;
    // move status
    [SerializeField] private bool moving;

    // next position number
    private int nextPosition;
    // moving positions
    public Vector3[] positions;

    // reference for player transform
    [Tooltip("Player shot position because is his center")]
    public Transform player;

    // current player position
    private Vector3 playerPos;

    // idle status
    private bool wasIdle;

    // already was idle
    private bool onceIdle;

    // time to reach the targe position
    public float timeToReachTarget;

    // facing direction
    private bool faceRight;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        parent = transform.parent;
        anim = GetComponent<Animator>();
        onceIdle = true;
        faceRight = true;
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (!moving)
            {
                nextPosition = GetNextPosition();
                moving = true;
                wasIdle = true;
            }
            MovePosition(nextPosition);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("AxeAttack"))
        {
            if (attack && wasIdle)
            {
                parent.position = Vector3.Lerp(parent.position, playerPos, timeToReachTarget);
            }
        }

    }

    /// <summary>
    /// Rotate the enemy in the moving direction
    /// </summary>
    /// <param name="position">target position</param>
    private void CheckRotate(Vector3 position)
    {
        if (parent.position != position)
        {
            if (parent.position.x > position.x && faceRight)
            {
                parent.transform.Rotate(0f, 180f, 0f);
                faceRight = false;
            }
            else if (parent.position.x < position.x && !faceRight)
            {
                parent.transform.Rotate(0f, 180f, 0f);
                faceRight = true;
            }
        }
    }

    /// <summary>
    /// return next target position 
    /// </summary>
    /// <returns></returns>
    public int GetNextPosition()
    {
        return Random.Range(0, positions.Length);
    }

    /// <summary>
    /// Move to a position
    /// </summary>
    /// <param name="nextPosition">target position</param>
    public void MovePosition(int nextPosition)
    {
        CheckRotate(positions[nextPosition]);
        parent.position = Vector2.MoveTowards(parent.position, positions[nextPosition], 1 * Time.deltaTime);

        if (parent.position == positions[nextPosition])
        {
            if (onceIdle)
            {
                Invoke("SetAttack", 1f);
                moving = false;
                onceIdle = false;
            }

        }
    }

    /// <summary>
    /// set bool after attack
    /// </summary>
    public void Attack()
    {
        attack = true;
    }

    /// <summary>
    /// Update player position and rotate towards him
    /// </summary>
    public void SetPlayerPos()
    {
        playerPos = player.position;
        CheckRotate(playerPos);
    }

    /// <summary>
    /// stop attack 
    /// </summary>
    public void StopAttack()
    {
        attack = false;
        wasIdle = false;
        Invoke("SetIdle", 1f);
    }

    /// <summary>
    /// trigger idle animation
    /// </summary>
    public void SetIdle()
    {
        anim.SetTrigger("Idle");
    }

    /// <summary>
    /// trigger attack
    /// </summary>
    public void SetAttack()
    {
        anim.SetTrigger("Attack");
        onceIdle = true;
    }
}

using UnityEngine;

public class GoblinBossAttack : MonoBehaviour
{
    Transform parent;
    public Animator anim;

    [SerializeField] private bool attack;
    [SerializeField] private bool moving;
    private int nextPosition;
    public Vector3[] positions;

    [Tooltip("Player shot position because is his center")]
    public Transform player;
    private Vector3 playerPos;
    private bool wasIdle;
    private bool onceIdle;
    public float timeToReachTarget;
    private bool faceRight;

    void Start()
    {
        parent = transform.parent;
        anim = GetComponent<Animator>();
        onceIdle = true;
        faceRight = true;
    }

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

    public int GetNextPosition()
    {
        return Random.Range(0, positions.Length);

    }

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

    public void Attack()
    {
        attack = true;
    }

    public void SetPlayerPos()
    {
        playerPos = player.position;
        CheckRotate(playerPos);
    }

    public void StopAttack()
    {
        attack = false;
        wasIdle = false;
        Invoke("SetIdle", 1f);
    }

    public void SetIdle()
    {
        anim.SetTrigger("Idle");
    }

    public void SetAttack()
    {
        anim.SetTrigger("Attack");
        onceIdle = true;
    }
}

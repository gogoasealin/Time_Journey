using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRollingMovement : EnemyMovement
{
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if(m_playerInSight)
        {
            //anim.SetTrigger("attack");
            Roll();
        }
        
    }

    public void Roll()
    {
        if (transform.position.x < GameController.instance.player.transform.position.x)
        {
            rb2d.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
            return;
        }
        rb2d.AddForce(Vector2.left * 10, ForceMode2D.Impulse);

    }

    public override void PlayerInSight()
    {
        m_playerInSight = true;
    }

    public override void PlayerOutOfSight()
    {
        m_playerInSight = false;
    }
}

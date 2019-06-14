using System;
using UnityEngine;

public class EnemyRollingMovement : MonoBehaviour
{
    public int m_enemyDamageAmount;
    public float speed;
    private Vector3 startPosition;
    public bool roll;

    public Action Roll = delegate { };

    private void Start()
    {
        startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (roll)
        {
            Roll();
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void RollRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, Time.deltaTime * speed);
    }

    public void RollLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.right, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameController.instance.player.GetComponent<PlayerHealth>().GetDamage(m_enemyDamageAmount);
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag.Equals("Breakable"))
        {
            other.gameObject.GetComponent<Health>().Die();
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        roll = false;
        gameObject.transform.position = startPosition;
        SetRotation(false);
        Invoke("Enable", 2f);
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }

    public void SetRotation(bool status)
    {
        var rotation = GetComponentInChildren<ParticleSystem>().rotationOverLifetime;
        if (status)
        {
            rotation.zMultiplier = 1500;
        }
        else
        {
            rotation.zMultiplier = 0;
        }
    }
}

using System;
using UnityEngine;

public class EnemyRollingMovement : MonoBehaviour
{
    // damage amount
    public int m_enemyDamageAmount;

    // speed 
    public float speed;

    // start position
    private Vector3 startPosition;

    // roll status
    public bool roll;

    // Roll action 
    public Action Roll = delegate { };

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        startPosition = gameObject.transform.position;
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        // check roll
        if (roll)
        {
            //call Roll
            Roll();
        }
    }

    /// <summary>
    /// Disable object
    /// </summary>
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Roll to the right
    /// </summary>
    public void RollRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, Time.deltaTime * speed);
    }

    /// <summary>
    /// Roll to the left
    /// </summary>
    public void RollLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.right, Time.deltaTime * speed);
    }

    /// <summary>
    /// Handle the collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other"> the Gameobject that is colliding with this</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check if the other gameobject has tag Player    
        if (other.gameObject.tag.Equals("Player"))
        {
            GameController.instance.player.GetComponent<PlayerHealth>().GetDamage(m_enemyDamageAmount);
            gameObject.SetActive(false);
        }


        //Check if the other gameobject has tag Breakable    
        if (other.gameObject.tag.Equals("Breakable"))
        {
            other.gameObject.GetComponent<Health>().Die();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    private void OnDisable()
    {
        roll = false;
        gameObject.transform.position = startPosition;
        SetRotation(false);
        Invoke("Enable", 2f);
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>

    private void Enable()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Set rotation
    /// </summary>
    /// <param name="status"></param>
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

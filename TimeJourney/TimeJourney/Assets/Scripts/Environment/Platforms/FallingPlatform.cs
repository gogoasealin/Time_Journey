using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    //start position
    private Vector3 startPosition;

    // fall delay
    public float fallColdown = 1f;

    // fall duration
    public float fallTime = 1.5f;

    // respawn time
    public float respawnTime = 2f;

    // called status
    protected bool called;

    /// <summary>
    /// MonoBehaviour Awake function
    /// </summary>
    private void Awake()
    {
        startPosition = transform.position;
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// Handle the collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other"> the Gameobject that is colliding with this</param>
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        //Check if the other gameobject has tag Player 
        if (other.gameObject.CompareTag("Player") && !called)
        {
            Invoke("Fall", fallColdown);
            called = true;
        }
    }

    /// <summary>
    /// Fall
    /// </summary>
    void Fall()
    {
        gameObject.AddComponent<Rigidbody2D>();
        Invoke("Disable", fallTime);
    }

    /// <summary>
    /// Disable
    /// </summary>
    void Disable()
    {
        Destroy(GetComponent<Rigidbody2D>());
        called = false;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    private void OnDisable()
    {
        Invoke("Respawn", respawnTime);
    }

    /// <summary>
    /// Respawn
    /// </summary>
    void Respawn()
    {
        //enable object
        gameObject.SetActive(true);
    }

}

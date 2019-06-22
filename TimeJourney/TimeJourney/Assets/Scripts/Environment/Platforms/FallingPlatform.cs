using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Vector3 startPosition;
    public float fallColdown = 1f;
    public float fallTime = 1.5f;
    public float respawnTime = 2f;

    private bool called;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !called)
        {
            Invoke("Fall", fallColdown);
            called = true;
        }
    }

    void Fall()
    {
        gameObject.AddComponent<Rigidbody2D>();
        Invoke("Disable", fallTime);
    }

    void Disable()
    {
        Destroy(GetComponent<Rigidbody2D>());
        called = false;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Invoke("Respawn", respawnTime);
    }

    void Respawn()
    {
        gameObject.SetActive(true);
    }

}

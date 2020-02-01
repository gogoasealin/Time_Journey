using UnityEngine;

public class EnemyShotStreightMovement : MonoBehaviour
{
    // object speed
    public float speed = 5;

    // target destionation
    private Vector3 destination;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        destination = (transform.GetChild(1).position * 100 - transform.position * 100);
        Invoke("DisableShot", 5f);
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination * 100, Time.deltaTime * speed);
    }

    /// <summary>
    /// Disable shot
    /// </summary>
    private void DisableShot()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.instance.player.GetComponent<PlayerHealth>().GetDamage(30);
            Destroy(gameObject);
        }
    }
}

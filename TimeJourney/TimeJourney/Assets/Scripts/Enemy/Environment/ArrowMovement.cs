using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    // arrow movementspeed
    public float speed = 200;
    // Position where arrow should go
    public Vector3 positionToReach;
    // the rigidbody of the current arrow
    private Rigidbody2D rb2d;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        var dir = positionToReach - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb2d.AddForce(transform.right * speed);
        rb2d.angularVelocity = 200f;
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        if (rb2d != null)
        {
            rb2d.AddForce(transform.right * speed);
            rb2d.angularVelocity = 200f;
        }
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player
        if (other.gameObject.tag == "Player")
        {
            GameController.instance.GameOver();
        }
        //Check if the other gameobject has tag Shot
        if (other.gameObject.tag == "Shot")
        {
            other.gameObject.SetActive(false);
        }
        //Check if the other gameobject has tag BackGround, Breakable or Enemy
        if (other.gameObject.tag == "BackGround" || other.gameObject.tag == "Breakable" || other.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}

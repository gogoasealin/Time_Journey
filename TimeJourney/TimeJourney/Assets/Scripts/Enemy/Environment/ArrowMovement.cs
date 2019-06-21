using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 200;
    public Vector3 positionToReach;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        var dir = positionToReach - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb2d.AddForce(transform.right * speed);
        rb2d.angularVelocity = 200f;
    }

    private void OnEnable()
    {
        if (rb2d != null)
        {
            rb2d.AddForce(transform.right * speed);
            rb2d.angularVelocity = 200f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameController.instance.GameOver();
        }
        if (other.gameObject.tag == "Shot")
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "BackGround" || other.gameObject.tag == "Breakable" || other.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}

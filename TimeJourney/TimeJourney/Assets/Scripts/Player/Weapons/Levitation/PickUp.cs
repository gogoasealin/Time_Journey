using UnityEngine;

public class PickUp : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            enabled = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, StoneAttacks.instance.cam.ScreenToWorldPoint(Input.mousePosition), 1f * Time.deltaTime);
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        enabled = false;
    }
}
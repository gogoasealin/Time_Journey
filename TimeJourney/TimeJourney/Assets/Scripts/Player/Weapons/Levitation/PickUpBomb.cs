using UnityEngine;

public class PickUpBomb : MonoBehaviour
{
    public Sprite deafult;
    public Sprite levitation;

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            enabled = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, StoneAttacks.instance.cam.ScreenToWorldPoint(Input.mousePosition), 2f * Time.deltaTime);
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<SpriteRenderer>().sprite = levitation;
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<SpriteRenderer>().sprite = deafult;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        enabled = false;
    }

}

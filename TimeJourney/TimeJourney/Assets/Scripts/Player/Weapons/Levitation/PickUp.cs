using UnityEngine;

public class PickUp : MonoBehaviour
{
    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    void Update()
    {
        // if player use button 1
        if (Input.GetMouseButtonUp(1))
        {
            enabled = false;
        }
        //set transform position
        transform.position = Vector2.MoveTowards(transform.position, StoneAttacks.instance.cam.ScreenToWorldPoint(Input.mousePosition), 2f * Time.deltaTime);
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    /// <summary>
    /// Handle the collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other"> the Gameobject that is colliding with this</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        //on collision with anything disable
        enabled = false;
    }
}
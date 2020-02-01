using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    // target 
    public Vector3 target;

    //speed
    public float speed = 1;

    //destination
    private Vector3 destination;

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        //set transform position
        transform.position = Vector2.MoveTowards(transform.position, destination * 100, Time.deltaTime * speed);
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        destination = (target * 100 - transform.position * 100);
        Invoke("DisableShot", 0.7f);
    }

    /// <summary>
    /// Disable shot
    /// </summary>
    private void DisableShot()
    {
        //disable gameobject
        gameObject.SetActive(false);
    }
}

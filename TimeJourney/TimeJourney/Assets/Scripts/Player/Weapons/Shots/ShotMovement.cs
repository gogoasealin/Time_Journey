using UnityEngine;

public class ShotMovement : MonoBehaviour
{

    public Vector3 target;
    public float speed = 1;
    private Vector3 destination;

    private void OnEnable()
    {
        destination = (target * 100 - transform.position * 100);
        Invoke("DisableShot", 0.7f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination * 100, Time.deltaTime * speed);
    }


    private void DisableShot()
    {
        gameObject.SetActive(false);
    }
}

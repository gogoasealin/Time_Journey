using UnityEngine;

public class EnemyShotMovement : MonoBehaviour
{
    public float speed = 5;
    private Vector3 destination;

    private void OnEnable()
    {
        destination = (GameController.instance.player.transform.GetChild(8).transform.position * 100 - transform.position * 100);
        Invoke("DisableShot", 5f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination * 100, Time.deltaTime * speed);
    }


    private void DisableShot()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.instance.player.GetComponent<PlayerHealth>().GetDamage(30);
            Destroy(gameObject);
        }
    }
}

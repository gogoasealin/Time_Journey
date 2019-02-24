using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour {

    public Vector3 target;
    public float speed = 1;
    private Vector3 destination;

    private void OnEnable()
    {
        destination = (target - transform.position) * 100; 
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        if(transform.position == target)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}

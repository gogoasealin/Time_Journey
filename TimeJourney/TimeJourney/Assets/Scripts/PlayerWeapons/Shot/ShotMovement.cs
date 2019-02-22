using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour {

    public Vector3 target;
    public float speed = 1;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if(transform.position == target)
        {
            gameObject.SetActive(false);
        }
    }

}

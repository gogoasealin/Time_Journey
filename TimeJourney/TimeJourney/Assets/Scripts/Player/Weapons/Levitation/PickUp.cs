using UnityEngine;

public class PickUp : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            GetComponent<PickUp>().enabled = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, StoneAttacks.instance.cam.ScreenToWorldPoint(Input.mousePosition), 1f * Time.deltaTime);
    }
}
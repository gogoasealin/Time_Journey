using UnityEngine;

public class BreakableObjectHealth : Health
{
    public GameObject objectToSwitch;

    public override void Die()
    {
        Instantiate(objectToSwitch, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}

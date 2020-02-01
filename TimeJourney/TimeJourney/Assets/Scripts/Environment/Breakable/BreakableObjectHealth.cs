using UnityEngine;

public class BreakableObjectHealth : Health
{
    // reference to object to switch
    public GameObject objectToSwitch;

    /// <summary>
    /// Logic when the current object die/break
    /// </summary>
    public override void Die()
    {
        // Instantiate new object to switch
        Instantiate(objectToSwitch, transform.position, Quaternion.identity);
        // disable current object
        gameObject.SetActive(false);
    }
}

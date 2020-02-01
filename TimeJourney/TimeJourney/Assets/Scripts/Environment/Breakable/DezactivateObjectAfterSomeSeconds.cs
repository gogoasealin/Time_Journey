using UnityEngine;

public class DezactivateObjectAfterSomeSeconds : MonoBehaviour
{
    // delay time
    public float delayTime = 2f;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        // Invoke Disable after delay
        Invoke("Disable", delayTime);
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    private void Disable()
    {
        // destroy current object
        Destroy(gameObject);
    }

}

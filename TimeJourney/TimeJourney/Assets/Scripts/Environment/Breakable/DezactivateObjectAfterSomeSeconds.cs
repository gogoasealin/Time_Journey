using UnityEngine;

public class DezactivateObjectAfterSomeSeconds : MonoBehaviour
{
    public float delayTime = 2f;

    private void OnEnable()
    {
        Invoke("Disable", delayTime);
    }

    private void Disable()
    {
        Destroy(gameObject);
    }

}

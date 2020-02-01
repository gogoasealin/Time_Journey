using UnityEngine;

public class DestroySimplePlayerAwake : MonoBehaviour
{
    // reference to switch new player
    public SwitchNewPlayer snp;

    /// <summary>
    /// MonoBehaviour Awake function
    /// </summary>
    private void Awake()
    {
        if (transform.position != Vector3.zero)
        {
            snp.GivePlayerItems();
            Destroy(gameObject);
        }
    }
}

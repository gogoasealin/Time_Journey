using UnityEngine;

public class DestroySimplePlayerAwake : MonoBehaviour
{
    public SwitchNewPlayer snp;
    private void Awake()
    {
        if (transform.position != Vector3.zero)
        {
            snp.GivePlayerItems();
            Destroy(gameObject);
        }
    }
}

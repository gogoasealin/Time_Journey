using UnityEngine;

public class FinalBossMovement : MonoBehaviour
{
    public GameObject wizzardPortal;
    public GameObject shot;

    private void OnEnable()
    {
        transform.localScale = new Vector3(0.03f, 0.03f, 0);
        GetComponent<FinalBossEnterFromPortal>().enabled = true;
    }

    public void Attack()
    {
        Debug.Log("attack");
        // use animation attack;
        // create 3 fire balls
    }
}

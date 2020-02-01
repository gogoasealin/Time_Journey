using UnityEngine;

public class GoblinBossEnter : BossEnter
{
    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        // object scale
        transform.localScale += new Vector3(0.001f, 0.001f, 0);
        if (transform.localScale.x >= 0.1f)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0);
            //enable script from children
            GetComponentInChildren<GoblinBossAttack>().enabled = true;
            //disable this script
            enabled = false;
        }
    }
}

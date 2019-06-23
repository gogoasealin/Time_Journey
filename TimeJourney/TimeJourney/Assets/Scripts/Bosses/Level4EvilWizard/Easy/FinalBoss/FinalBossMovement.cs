using System.Collections;
using UnityEngine;

public class FinalBossMovement : MonoBehaviour
{
    public GameObject wizzardPortal;
    public GameObject shot;
    private IEnumerator attack;

    private void OnEnable()
    {
        transform.localScale = new Vector3(0.03f, 0.03f, 0);
        GetComponent<FinalBossEnterFromPortal>().enabled = true;
    }

    public void Attack()
    {
        attack = StartAttack();
        StartCoroutine(attack);
    }

    IEnumerator StartAttack()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

        GetComponent<FinalBossHealth>().SetBossColorState(true);
        Invoke("RetreatBoss", 2f);
    }

    void RetreatBoss()
    {
        GetComponent<FinalBossHealth>().SetBossColorState(false);
        GetComponent<WizardBossRetreat>().enabled = true;
    }


}

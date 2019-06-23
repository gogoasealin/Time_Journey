using System.Collections;
using UnityEngine;

public class FinalBossMovement : MonoBehaviour
{
    public GameObject wizzardPortal;
    public GameObject shot;
    public GameObject shotStraight;
    public GameObject shotDiagonally;
    private IEnumerator attack;
    public bool normal;


    private void OnEnable()
    {
        transform.localScale = new Vector3(0.03f, 0.03f, 0);
        GetComponent<FinalBossEnterFromPortal>().enabled = true;
    }

    public void Attack()
    {
        if (normal)
        {
            attack = StartAttackNormal();
        }
        else
        {
            attack = StartAttack();
        }
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

    IEnumerator StartAttackNormal()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0)
            {
                Instantiate(shotStraight, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(shotDiagonally, transform.position, Quaternion.identity);
            }
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

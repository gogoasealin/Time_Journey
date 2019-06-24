using System.Collections;
using UnityEngine;

public class FinalBossMovementV2 : MonoBehaviour
{
    public GameObject HurtingPortal;
    public Vector3[] positions;
    public GameObject shot;
    private IEnumerator attack;
    public bool normal;
    public bool freezed;
    public float timeFreezed;
    public SpriteRenderer[] bodyParts;
    public GameObject tutorialText;

    private bool once;
    private void OnEnable()
    {
        if (!once)
        {
            once = true;
            return;
        }

        if(normal)
        {
            tutorialText.SetActive(true);
        }

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
        for (int i = 0; i < 10; i++)
        {
            int random = Random.Range(0, positions.Length);
            Instantiate(HurtingPortal, positions[random], Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        GetComponent<FinalBossHealth>().SetBossColorState(true);
        Invoke("RetreatBoss", 2f);
    }

    IEnumerator StartAttackNormal()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

        if (!freezed)
        {
            Retreat();
        }
    }

    void RetreatBoss()
    {
        GetComponent<FinalBossHealth>().SetBossColorState(false);
        GetComponent<WizardBossRetreat>().enabled = true;
    }

    void Retreat()
    {
        CancelInvoke();
        for (int j = 0; j < bodyParts.Length; j++)
        {
            bodyParts[j].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
        GetComponent<WizardBossRetreat>().enabled = true;
    }

    public void Freeze()
    {
        for (int j = 0; j < bodyParts.Length; j++)
        {
            bodyParts[j].GetComponent<SpriteRenderer>().color = new Color(0, 1, 1);
        }
        freezed = true;
        GetComponent<FinalBossHealth>().receiveDMG = true;
        Invoke("DisableFreeze", timeFreezed);
    }

    public void DisableFreeze()
    {
        freezed = false;
        GetComponent<FinalBossHealth>().receiveDMG = false;
        Retreat();

    }
}

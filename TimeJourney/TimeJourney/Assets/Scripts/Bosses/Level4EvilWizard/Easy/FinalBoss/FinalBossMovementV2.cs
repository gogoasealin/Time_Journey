using System.Collections;
using UnityEngine;

public class FinalBossMovementV2 : MonoBehaviour
{
    // reference to hurting portal object
    public GameObject HurtingPortal;

    // positions where the boss can move
    public Vector3[] positions;

    // reference to the shot
    public GameObject shot;

    // reference to attack Coroutine
    private IEnumerator attack;

    // attack type;
    public bool normal;

    // freezed status
    public bool freezed;

    // freeze duration
    public float timeFreezed;

    // reference for body parts
    public SpriteRenderer[] bodyParts;

    // reference to tutorial Text
    public GameObject tutorialText;

    // status for only one time action
    private bool once;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        if (!once)
        {
            once = true;
            return;
        }

        if (normal)
        {
            tutorialText.SetActive(true);
        }

        transform.localScale = new Vector3(0.03f, 0.03f, 0);
        GetComponent<FinalBossEnterFromPortal>().enabled = true;
    }

    /// <summary>
    /// Trigger attack
    /// </summary>
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

    /// <summary>
    /// attack coroutine 
    /// </summary>
    /// <returns></returns>
    IEnumerator StartAttack()
    {
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, positions.Length);
            Instantiate(HurtingPortal, positions[random], Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        GetComponent<FinalBossHealth>().SetBossColorState(true);
        Invoke("RetreatBoss", 2f);
    }

    /// <summary>
    /// normal attack coroutine
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// retreat boss 
    /// </summary>
    void RetreatBoss()
    {
        GetComponent<FinalBossHealth>().SetBossColorState(false);
        GetComponent<WizardBossRetreat>().enabled = true;
    }

    /// <summary>
    /// retreat
    /// </summary>
    void Retreat()
    {
        CancelInvoke();
        for (int j = 0; j < bodyParts.Length; j++)
        {
            bodyParts[j].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
        GetComponent<WizardBossRetreat>().enabled = true;
    }

    /// <summary>
    /// Freeze
    /// </summary>
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

    /// <summary>
    /// Unfreeze
    /// </summary>
    public void DisableFreeze()
    {
        freezed = false;
        GetComponent<FinalBossHealth>().receiveDMG = false;
        Retreat();

    }
}

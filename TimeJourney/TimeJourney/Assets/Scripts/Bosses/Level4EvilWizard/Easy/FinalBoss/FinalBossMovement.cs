using System.Collections;
using UnityEngine;

public class FinalBossMovement : MonoBehaviour
{
    // reference to the shot
    public GameObject shot;

    // reference to the straight shot
    public GameObject shotStraight;

    // reference to the diagonally shot
    public GameObject shotDiagonally;

    // reference to attack Coroutine
    private IEnumerator attack;

    // attack type;
    public bool normal;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        // change object scale
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
        for (int i = 0; i < 3; i++)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
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

    /// <summary>
    /// retreat boss 
    /// </summary>
    void RetreatBoss()
    {
        GetComponent<FinalBossHealth>().SetBossColorState(false);
        GetComponent<WizardBossRetreat>().enabled = true;
    }


}

using System.Collections;
using UnityEngine;

public class FinalBossEnter : MonoBehaviour
{
    public SpriteRenderer[] bodyParts;
    private IEnumerator black;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Black());
    }

    IEnumerator Black()
    {
        float colorValue = 1;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < bodyParts.Length; j++)
            {
                bodyParts[j].GetComponent<SpriteRenderer>().color = new Color(colorValue, colorValue, colorValue);
            }
            colorValue -= 0.2f;
            yield return new WaitForSeconds(.05f);
        }
        Invoke("Disable", 1f);
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}

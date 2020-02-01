using System.Collections;
using UnityEngine;

public class FinalBossEnter : MonoBehaviour
{
    // reference for body parts
    public SpriteRenderer[] bodyParts;

    // Coroutine for changing boss color
    private IEnumerator black;

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Black());
    }

    /// <summary>
    /// Coroutine for changing boss color to black
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Disable this object
    /// </summary>
    private void Disable()
    {
        Destroy(gameObject);
    }
}

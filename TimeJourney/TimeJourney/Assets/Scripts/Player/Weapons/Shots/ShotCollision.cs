using UnityEngine;

public class ShotCollision : MonoBehaviour
{
    public string Type;
    public int ShotDamageAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Ground") || other.tag.Equals("Breakable"))
        {
            gameObject.SetActive(false);
            return;
        }

        if (other.tag.Equals("Enemy") && !other.gameObject.name.Contains("Shot"))
        {
            other.GetComponent<Health>().GetDamage(Type, ShotDamageAmount);
            gameObject.SetActive(false);
        }
    }
}

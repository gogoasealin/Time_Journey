using UnityEngine;

public class ShotCollision : MonoBehaviour
{
    // type
    public string Type;

    //damage amount
    public int ShotDamageAmount;

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Ground or Breakable
        if (other.tag.Contains("Ground") || other.tag.Equals("Breakable"))
        {
            gameObject.SetActive(false);
            return;
        }

        //Check if the other gameobject has tag Enemy or contains Shot
        if (other.tag.Equals("Enemy") && !other.gameObject.name.Contains("Shot"))
        {
            other.GetComponent<Health>().GetDamage(Type, ShotDamageAmount);
            gameObject.SetActive(false);
        }
    }
}

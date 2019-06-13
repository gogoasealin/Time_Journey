using UnityEngine;

public class Breakable : MonoBehaviour
{
    public int health = 1;

    public virtual void GetDamage(int amount, string type = "")
    {
        health -= amount;
        if (health < 0)
        {
            Die();
        }
    }

    public virtual void Die() { }

}

using UnityEngine;

/// <summary>
/// Base clase for all Health type classes 
/// </summary>
public class Health : MonoBehaviour
{
    // start hp
    public int m_maxHp = 100;
    // curent health value
    public int m_CurrentHealth;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    public virtual void Start()
    {
        m_CurrentHealth = m_maxHp;
    }

    /// <summary>
    /// Receive damage from hit (with sword for enemy, and by enemy body for player)
    /// </summary>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public virtual void GetDamage(int dmgAmount)
    {
    }

    /// <summary>
    /// Receive damage from player stones
    /// </summary>
    /// <param name="type">stone attack type (fire, ice, light)</param>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public virtual void GetDamage(string type, int dmgAmount)
    {
    }

    /// <summary>
    /// Logic when the current object die
    /// </summary>
    public virtual void Die()
    {
        //disaable the object
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Play animation for receiving damage
    /// </summary>
    public virtual void GetDamageAnimation()
    {
    }

}

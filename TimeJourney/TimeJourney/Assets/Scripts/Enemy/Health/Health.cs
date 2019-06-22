using UnityEngine;

public class Health : MonoBehaviour
{
    public int m_maxHp = 100;
    public int m_CurrentHealth;

    public virtual void Start()
    {
        m_CurrentHealth = m_maxHp;
    }

    public virtual void GetDamage(int dmgAmount)
    {
    }

    public virtual void GetDamage(string type, int dmgAmount)
    {
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
    }

    public virtual void GetDamageAnimation()
    {
    }

}

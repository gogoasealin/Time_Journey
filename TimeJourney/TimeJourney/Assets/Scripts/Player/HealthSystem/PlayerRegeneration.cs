using UnityEngine;

public class PlayerRegeneration : MonoBehaviour
{
    // reference to player health
    PlayerHealth playerhealth;

    // damage receive status
    private bool m_damageReceive;
    public bool m_DamageReceive
    {
        get => m_damageReceive;
        set
        {
            m_healthTimer = 0;
            m_damageReceive = value;
        }
    }

    // recover health timer
    public float m_healthTimer;

    // regeneration start delay
    public float m_RegenerationStartDelay;

    // regeneration amount
    public float m_RegenerationAmoount;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        // set player health
        playerhealth = GetComponent<PlayerHealth>();
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    void Update()
    {
        // check if received damage
        if (m_DamageReceive)
        {
            m_healthTimer += Time.deltaTime;
            if (m_healthTimer >= m_RegenerationStartDelay)
            {
                playerhealth.m_CurrentHealth += m_RegenerationAmoount;
                if (playerhealth.m_CurrentHealth > 100)
                {
                    playerhealth.m_CurrentHealth = 100;
                    m_DamageReceive = false;
                }
            }
        }
    }
}

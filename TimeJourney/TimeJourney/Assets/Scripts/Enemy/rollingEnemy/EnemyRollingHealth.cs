public class EnemyRollingHealth : Health
{
    // receive damage status
    public bool getDMG;

    /// <summary>
    /// Receive damage from hit (with sword for enemy, and by enemy body for player)
    /// </summary>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public override void GetDamage(int dmgAmount)
    {
        // check receive damage status 
        if (getDMG)
        {
            // call base class
            base.GetDamage(dmgAmount);
        }
    }
    /// <summary>
    /// Receive damage from player stones
    /// </summary>
    /// <param name="type">stone attack type (fire, ice, light)</param>
    /// <param name="dmgAmount">amount of damage to receive</param>
    public override void GetDamage(string type, int dmgAmount)
    {
        // check receive damage status 
        if (getDMG)
        {
            // call base class
            base.GetDamage(type, dmgAmount);
        }
    }
}

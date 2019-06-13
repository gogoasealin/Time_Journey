public class EnemyRollingHealth : Health
{
    public bool getDMG;
    public override void GetDamage(int dmgAmount)
    {
        if (getDMG)
        {
            base.GetDamage(dmgAmount);
        }
    }

    public override void GetDamage(string type, int dmgAmount)
    {
        if (getDMG)
        {
            base.GetDamage(type, dmgAmount);
        }
    }
}

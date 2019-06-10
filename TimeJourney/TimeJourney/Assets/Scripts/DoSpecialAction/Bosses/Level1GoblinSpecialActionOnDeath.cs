public class Level1GoblinSpecialActionOnDeath : SpecialAction
{
    public GoblinBossEnter goblinBossEnter;

    public override void DoSpecialAction()
    {
        GetComponent<TriggerBossFight>().enabled = true;
        goblinBossEnter.enabled = true;
        GetComponent<TriggerBossFight>().Revert();
    }
}

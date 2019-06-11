public class Level1GoblinSpecialActionOnDeath : SpecialAction
{
    public override void DoSpecialAction()
    {
        gameObject.SetActive(true);
        GetComponent<TriggerBossFight>().Revert();
    }
}

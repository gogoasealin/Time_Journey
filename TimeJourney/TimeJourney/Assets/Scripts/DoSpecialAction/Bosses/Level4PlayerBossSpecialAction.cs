public class Level4PlayerBossSpecialAction : SpecialAction
{
    public override void DoSpecialAction()
    {
        gameObject.SetActive(true);
        GetComponent<TriggerBossFight>().Revert();
    }
}

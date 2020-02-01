public class Level1GoblinSpecialActionOnDeath : SpecialAction
{
    /// <summary>
    /// Do special Action 
    /// </summary>
    public override void DoSpecialAction()
    {
        // disable object
        gameObject.SetActive(true);
        GetComponent<TriggerBossFight>().Revert();
    }
}

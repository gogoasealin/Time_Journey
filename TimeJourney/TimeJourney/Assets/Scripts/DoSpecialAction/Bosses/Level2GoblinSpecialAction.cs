using UnityEngine;

public class Level2GoblinSpecialAction : SpecialAction
{
    // references to boxes
    public GameObject[] boxes;

    // reference to multi switch manager
    public MultiSwitchManager msm;

    /// <summary>
    /// Do special Action 
    /// </summary>
    public override void DoSpecialAction()
    {
        // disable object
        gameObject.SetActive(true);
        GetComponent<TriggerBossFight>().Revert();
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i].SetActive(true);
        }
        msm.Reset();
    }
}

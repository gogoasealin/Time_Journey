using UnityEngine;

public class Level2GoblinSpecialAction : SpecialAction
{
    public GameObject[] boxes;
    public override void DoSpecialAction()
    {
        gameObject.SetActive(true);
        GetComponent<TriggerBossFight>().Revert();
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i].SetActive(true);
        }
    }
}

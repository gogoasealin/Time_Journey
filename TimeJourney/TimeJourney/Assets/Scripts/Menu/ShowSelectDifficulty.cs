using UnityEngine;

public class ShowSelectDifficulty : MonoBehaviour
{
    //reference to object to show
    public GameObject toShow;

    /// <summary>
    /// Show Select Difficulty window
    /// </summary>
    public void ShowDifficultySelect()
    {
        toShow.SetActive(true);
    }

    /// <summary>
    /// Hide Select Difficulty window
    /// </summary>
    public void hideDifficultySelect()
    {
        toShow.SetActive(false);
    }
}

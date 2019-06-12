using UnityEngine;

public class ShowSelectDifficulty : MonoBehaviour
{
    public GameObject toShow;
    public void ShowDifficultySelect()
    {
        toShow.SetActive(true);
    }

    public void hideDifficultySelect()
    {
        toShow.SetActive(false);
    }
}

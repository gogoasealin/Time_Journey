using UnityEngine;

public class CheckContinueButton : MonoBehaviour
{
    public SaveSystemSO saveSystemSO;

    private void Start()
    {
        if (saveSystemSO.m_Difficulty.Length == 0 && saveSystemSO.m_SceneName == "IntroCity")
        {
            gameObject.SetActive(false);
        }
    }
}

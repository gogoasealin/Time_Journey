using UnityEngine;

public class CheckContinueButton : MonoBehaviour
{
    //reference to save system
    public SaveSystemSO saveSystemSO;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        if (saveSystemSO.m_Difficulty.Length == 0 && saveSystemSO.m_SceneName == "IntroCity")
        {
            // disable gameobject
            gameObject.SetActive(false);
        }
    }
}

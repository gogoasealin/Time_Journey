using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public SaveSystemSO saveSystemSO;

    public void ChangeDifficulty(string type)
    {
        saveSystemSO.m_Difficulty = type;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(saveSystemSO.m_SceneName + saveSystemSO.m_Difficulty);
    }

    public void ContinueGame()
    {
        saveSystemSO.m_LoadGame = true;
        SceneManager.LoadScene(saveSystemSO.m_SceneName + saveSystemSO.m_Difficulty);
    }
}

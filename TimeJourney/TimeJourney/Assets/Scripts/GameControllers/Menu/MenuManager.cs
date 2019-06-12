using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public SaveSystemSO saveSystemSO;

    public void SelectDifficulty(string type)
    {
        saveSystemSO.m_Difficulty = type;
        StartNewGame();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("IntroCity");
    }

    public void ContinueGame()
    {
        saveSystemSO.m_LoadGame = true;
        SceneManager.LoadScene(saveSystemSO.m_SceneName + saveSystemSO.m_Difficulty);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}


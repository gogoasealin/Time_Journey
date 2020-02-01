using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //reference to save system
    public SaveSystemSO saveSystemSO;

    /// <summary>
    /// Select Difficulty 
    /// </summary>
    /// <param name="type">difficulty type</param>
    public void SelectDifficulty(string type)
    {
        // set difficulty
        saveSystemSO.m_Difficulty = type;

        // call start new game
        StartNewGame();
    }

    /// <summary>
    /// Start new game
    /// </summary>
    public void StartNewGame()
    {
        // load IntroCity scene
        SceneManager.LoadScene("IntroCity");
    }

    /// <summary>
    /// Continue Game
    /// </summary>
    public void ContinueGame()
    {
        saveSystemSO.m_LoadGame = true;
        SceneManager.LoadScene(saveSystemSO.m_SceneName + saveSystemSO.m_Difficulty);
    }

    /// <summary>
    /// Quit Game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}


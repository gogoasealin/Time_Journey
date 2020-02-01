using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // reference to gamecontroller singleton instance
    public static GameController instance;

    // reference to the player 
    public GameObject player;

    // reference to the sword logic 
    public GameObject swordLogic;

    //reference to save system
    public SaveSystemSO saveSystemSO;

    // player death status
    private bool m_death;

    //reference to special action
    public Action SpecialAction = delegate { };

    // Menu
    GameObject m_Menu;

    /// <summary>
    /// MonoBehaviour Awake function
    /// </summary>
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        LoadGame();
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Revive();
        }

        CheckInput();

        if (Input.GetKeyDown(KeyCode.P))
        {
            saveSystemSO.m_LoadGame = true;
            LoadGame();
        }

    }

    /// <summary>
    /// CheckInput
    /// </summary>
    public void CheckInput()
    {
        if (Input.GetKeyDown("[1]"))
        {
            SceneManager.LoadScene("Level1Easy");
        }
        if (Input.GetKeyDown("[2]"))
        {
            SceneManager.LoadScene("Level2Easy");
        }
        if (Input.GetKeyDown("[3]"))
        {
            SceneManager.LoadScene("Level3Easy");
        }
        if (Input.GetKeyDown("[4]"))
        {
            SceneManager.LoadScene("Level4Easy");
        }
        if (Input.GetKeyDown("[5]"))
        {
            SceneManager.LoadScene("Level5Easy");
        }
        if (Input.GetKeyDown("[6]"))
        {
            SceneManager.LoadScene("Level1Normal");
        }
        if (Input.GetKeyDown("[7]"))
        {
            SceneManager.LoadScene("Level2Normal");
        }
        if (Input.GetKeyDown("[8]"))
        {
            SceneManager.LoadScene("Level3Normal");
        }
        if (Input.GetKeyDown("[9]"))
        {
            SceneManager.LoadScene("Level4Normal");
        }
        if (Input.GetKeyDown("[0]"))
        {
            SceneManager.LoadScene("Level5Normal");
        }
    }

    /// <summary>
    /// GameOver
    /// </summary>
    public void GameOver()
    {
        if (!m_death)
        {
            m_death = true;

            Time.timeScale = 0;

            Revive();
        }
    }

    /// <summary>
    /// Revive
    /// </summary>
    private void Revive()
    {
        string currentSceneName = saveSystemSO.m_SceneName + saveSystemSO.m_Difficulty;

        if (currentSceneName.Equals(SceneManager.GetActiveScene().name))
        {
            GetComponent<RevivePlayer>().Revive();
        }
        else
        {
            player.transform.position = Vector3.zero;
        }
        m_death = false;
        Time.timeScale = 1;
        player.GetComponent<PlayerHealth>().Revive();
    }

    /// <summary>
    /// Save Game
    /// </summary>
    public void SaveGame()
    {
        saveSystemSO.m_PlayerPositionX = player.transform.position.x;
        saveSystemSO.m_PlayerPositionY = player.transform.position.y;
        //save current level name without the m_difficulty
        if (saveSystemSO.m_Difficulty.Contains("Easy"))
        {
            saveSystemSO.m_SceneName = SceneManager.GetActiveScene().name.Replace("Easy", "");
        }
        else if (saveSystemSO.m_Difficulty.Contains("Normal"))
        {
            saveSystemSO.m_SceneName = SceneManager.GetActiveScene().name.Replace("Normal", "");
        }

        if (GameSaveManager.instance != null)
        {
            GameSaveManager.instance.Save();
        }
    }

    /// <summary>
    /// Load Game
    /// </summary>
    public void LoadGame()
    {
        string currentSceneName = saveSystemSO.m_SceneName + saveSystemSO.m_Difficulty;
        if (!currentSceneName.Equals(SceneManager.GetActiveScene().name))
        {
            if (SceneManager.GetActiveScene().name.Contains("Level1"))
            {
                if (player.transform.position.x == -13.85f)
                {
                    SaveLevel1();
                    return;
                }
            }
            SaveGame();
        }
        if (!saveSystemSO.m_LoadGame)
        {
            return;
        }
        ///safe check for lvl1 
        if (SceneManager.GetActiveScene().name.Contains("Level1"))
        {
            if (player.transform.position.x == -13.85f)
            {
                saveSystemSO.m_LoadGame = false;
                return;
            }
        }
        player.transform.position = new Vector3(saveSystemSO.m_PlayerPositionX,
                                               saveSystemSO.m_PlayerPositionY,
                                               0);
        saveSystemSO.m_LoadGame = false;
    }

    /// <summary>
    /// Save Level1
    /// </summary>
    public void SaveLevel1()
    {
        saveSystemSO.m_PlayerPositionX = 0;
        saveSystemSO.m_PlayerPositionY = 0;
        //save current level name without the m_difficulty


        if (saveSystemSO.m_SceneName.Equals("IntroCity"))
        {
            if (SceneManager.GetActiveScene().name.Contains("Easy"))
            {
                saveSystemSO.m_SceneName = SceneManager.GetActiveScene().name.Replace("Easy", "");
            }
            else if (SceneManager.GetActiveScene().name.Contains("Normal"))
            {
                saveSystemSO.m_SceneName = SceneManager.GetActiveScene().name.Replace("Normal", "");
            }
        }
        else
        {
            if (saveSystemSO.m_SceneName.Contains("Easy"))
            {
                saveSystemSO.m_SceneName = SceneManager.GetActiveScene().name.Replace("Easy", "");
            }
            else if (saveSystemSO.m_SceneName.Contains("Normal"))
            {
                saveSystemSO.m_SceneName = SceneManager.GetActiveScene().name.Replace("Normal", "");
            }
        }

        if (GameSaveManager.instance != null)
        {
            GameSaveManager.instance.Save();
        }
    }

    /// <summary>
    /// Do Special ACtion
    /// </summary>
    public void DoSpecialAction()
    {
        SpecialAction();
    }

}
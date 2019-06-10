using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject player;
    public GameObject swordLogic;
    public SaveSystemSO saveSystemSO;
    private bool m_death;


    public Action SpecialAction = delegate { };


    // Menu
    GameObject m_Menu;

    //Revive

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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Revive();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.transform.position = new Vector3(58, 0, 0);
        }

    }

    public void GameOver()
    {
        if (!m_death)
        {
            m_death = true;

            Time.timeScale = 0;

            Revive();
        }
    }

    private void Revive()
    {
        GetComponent<RevivePlayer>().Revive();
        m_death = false;
        Time.timeScale = 1;
        player.GetComponent<PlayerHealth>().Revive();
    }

    public void SaveGame()
    {
        saveSystemSO.m_PlayerPosition = player.transform.position;
        //save current level name without the m_difficulty
        if (saveSystemSO.m_SceneName.Contains("Easy"))
        {
            saveSystemSO.m_SceneName = SceneManager.GetActiveScene().name.Replace("Easy", "");
        }
        else
        {
            saveSystemSO.m_SceneName = SceneManager.GetActiveScene().name.Replace("Normal", "");
        }

        if (MenuManager.instance != null)
        {
            MenuManager.instance.Save();
        }
    }

    public void LoadGame()
    {
        if (!saveSystemSO.m_LoadGame)
        {
            return;
        }
        player.transform.position = saveSystemSO.m_PlayerPosition;
        saveSystemSO.m_LoadGame = false;
    }

    public void DoSpecialAction()
    {
        SpecialAction();
    }
}
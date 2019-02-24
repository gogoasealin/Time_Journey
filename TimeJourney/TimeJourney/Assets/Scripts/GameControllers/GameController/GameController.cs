using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject player;
    public SaveSystemSO saveSystemSO;
    private bool m_death;

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
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            Revive();
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

    }

    public void SaveGame()
    {
        saveSystemSO.Save();
    }

    public void LoadGame()
    {
        saveSystemSO.Load();
    }

    public void SaveLastPlayerPosition()
    {
        GetComponent<RevivePlayer>().m_LastSavedPosition = player.transform.position;
    }
    
    public void LoadLastPlayerPosition(Vector3 playerPosition)
    {
        GetComponent<RevivePlayer>().m_LastSavedPosition = playerPosition;
        Revive();
    }


}

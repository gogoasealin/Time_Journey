using System;
using System.Collections;
using System.Collections.Generic;
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
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            Revive();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
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
        player.GetComponent<PlayerHealth>().SetHealth();
    }

    public void SaveGame()
    {
        saveSystemSO.m_PlayerPosition = player.transform.position;
        if (saveSystemSO.m_SceneName.Contains("Easy")) {
            saveSystemSO.m_SceneName = saveSystemSO.m_SceneName.Replace("Easy", "");
        }
        else
        {
            saveSystemSO.m_SceneName = saveSystemSO.m_SceneName.Replace("Normal", "");
        }
    }

    public void LoadGame()
    {
        if (!saveSystemSO.m_LoadGame)
            return;
        player.transform.position = saveSystemSO.m_PlayerPosition;

        saveSystemSO.m_LoadGame = false;
    }

    public void DoSpecialAction()
    {
        SpecialAction();
    }
}

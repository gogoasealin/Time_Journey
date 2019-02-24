using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject player;

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
    }

    public void Start()
    {
        SaveSystem.instance.Load();
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

    public void Revive()
    {
        GetComponent<RevivePlayer>().Revive();
    }

    public void SaveLastPlayerPosition()
    {
        GetComponent<RevivePlayer>().m_LastSavedPosition = player.transform.position;
    }
    
    public void LoadLastPlayerPosition(Vector3 playerPosition)
    {
        GetComponent<RevivePlayer>().m_LastSavedPosition = playerPosition;
        if(GameManager.instance.CheckCurrentScene())
        {
            Revive();
        }

    }


}

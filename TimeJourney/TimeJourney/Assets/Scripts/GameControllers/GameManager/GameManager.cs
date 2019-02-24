using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    public void ChangeScene()
    {
        if(SceneManager.GetActiveScene().name.Equals("Main"))
        {
            SceneManager.LoadScene("Main2");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }

    public bool CheckCurrentScene()
    {
        return SaveSystem.instance.m_SceneName.Equals(SceneManager.GetActiveScene().name);
    }
}

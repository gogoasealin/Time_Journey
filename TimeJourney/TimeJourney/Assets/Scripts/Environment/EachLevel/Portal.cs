using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string m_NextSceneName;
    public SaveSystemSO saveSystemSO;

    private bool onTrigger;

    public void Start()
    {
        onTrigger = false;
        m_NextSceneName += saveSystemSO.m_Difficulty;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            ChangeScene();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = false;
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(m_NextSceneName);
    }
}
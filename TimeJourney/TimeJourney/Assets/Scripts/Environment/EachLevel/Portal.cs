using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string m_NextSceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(m_NextSceneName);
    }
}

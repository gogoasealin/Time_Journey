using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    // next scene name
    public string m_nextSceneName;

    //reference to saveSystemSO
    public SaveSystemSO saveSystemSO;

    //reference to fade object
    public GameObject fade;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        m_nextSceneName += saveSystemSO.m_Difficulty;
    }

    /// <summary>
    /// Change current Scene
    /// </summary>
    public void ChangeScene()
    {
        StartCoroutine(LoadScene(m_nextSceneName));
    }

    /// <summary>
    /// Load scene
    /// </summary>
    /// <param name="Level">scene name to be loaded</param>
    /// <returns></returns>
    IEnumerator LoadScene(string Level)
    {
        fade.SetActive(true);
        fade.GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(Level);
    }
}

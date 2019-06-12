using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public string m_nextSceneName;
    public SaveSystemSO saveSystemSO;
    public GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
        m_nextSceneName += saveSystemSO.m_Difficulty;
    }

    public void ChangeScene()
    {
        StartCoroutine(LoadScene(m_nextSceneName));
    }

    IEnumerator LoadScene(string Level)
    {
        fade.SetActive(true);
        fade.GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(Level);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string m_NextSceneName;
    public SaveSystemSO saveSystemSO;
    public GameObject fade;
    public bool switchToNonLevelScene;
    public bool onTrigger;

    public void Start()
    {
        onTrigger = false;
        if(!switchToNonLevelScene)
        {
            m_NextSceneName += saveSystemSO.m_Difficulty;
        }
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
        StartCoroutine(LoadScene(m_NextSceneName));
    }

    IEnumerator LoadScene(string Level)
    {
        fade.SetActive(true);
        fade.GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(Level);
    }
}
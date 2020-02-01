using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // next scene name
    public string m_NextSceneName;

    //reference to saveSystemSO
    public SaveSystemSO saveSystemSO;

    //reference to fade object
    public GameObject fade;

    //switch status
    public bool switchToNonLevelScene;

    //trigger status
    public bool onTrigger;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    public void Start()
    {
        onTrigger = false;
        if (!switchToNonLevelScene)
        {
            m_NextSceneName += saveSystemSO.m_Difficulty;
        }
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            ChangeScene();
        }
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player
        if (other.CompareTag("Player"))
        {
            onTrigger = true;
        }
    }

    /// <summary>
    /// Handle the trigger collision exit between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    public void OnTriggerExit2D(Collider2D other)
    {
        //Check if the other gameobject has tag Player
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
        Destroy(GameController.instance);
        fade.SetActive(true);
        fade.GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(Level);
    }
}
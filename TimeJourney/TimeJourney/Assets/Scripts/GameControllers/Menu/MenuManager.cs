using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [HideInInspector] public static MenuManager instance;
    public SaveSystemSO saveSystemSO;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Load();
    }

    public void ChangeDifficulty(string type)
    {
        saveSystemSO.m_Difficulty = type;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(saveSystemSO.m_SceneName + saveSystemSO.m_Difficulty);
    }

    public void ContinueGame()
    {
        saveSystemSO.m_LoadGame = true;
        SceneManager.LoadScene(saveSystemSO.m_SceneName + saveSystemSO.m_Difficulty);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerInfo data = new PlayerInfo();

        data.m_PlayerPosition = saveSystemSO.m_PlayerPosition;
        data.m_SceneName = saveSystemSO.m_SceneName;
        data.m_Difficulty = saveSystemSO.m_Difficulty;

        bf.Serialize(file, data);
        file.Close();
    }


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);

            PlayerInfo data = (PlayerInfo)bf.Deserialize(file);

            saveSystemSO.m_PlayerPosition = data.m_PlayerPosition;
            saveSystemSO.m_SceneName = data.m_SceneName;
            saveSystemSO.m_Difficulty = data.m_Difficulty;

            file.Close();
        }
    }
}

[System.Serializable]
class PlayerInfo
{
    public Vector3 m_PlayerPosition;
    public string m_SceneName;
    public string m_Difficulty;
}
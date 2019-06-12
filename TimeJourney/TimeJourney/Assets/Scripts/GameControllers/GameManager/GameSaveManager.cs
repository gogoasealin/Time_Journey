using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{

    [HideInInspector] public static GameSaveManager instance;

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

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerInfo data = new PlayerInfo();

        data.m_PlayerPositionX = saveSystemSO.m_PlayerPositionX;
        data.m_PlayerPositionY = saveSystemSO.m_PlayerPositionY;
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

            saveSystemSO.m_PlayerPositionX = data.m_PlayerPositionX;
            saveSystemSO.m_PlayerPositionY = data.m_PlayerPositionY;
            saveSystemSO.m_SceneName = data.m_SceneName;
            saveSystemSO.m_Difficulty = data.m_Difficulty;

            file.Close();
        }
        else
        {
            saveSystemSO.m_PlayerPositionX = 0;
            saveSystemSO.m_PlayerPositionY = 0;
            saveSystemSO.m_SceneName = "IntroCity";
            saveSystemSO.m_Difficulty = "";
        }
    }
}

[System.Serializable]
class PlayerInfo
{
    public float m_PlayerPositionX;
    public float m_PlayerPositionY;
    public string m_SceneName;
    public string m_Difficulty;
}
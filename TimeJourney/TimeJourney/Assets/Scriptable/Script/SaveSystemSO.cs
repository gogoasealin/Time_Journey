using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SaveSystemSO")]
public class SaveSystemSO : ScriptableObject
{
    public Vector3 m_PlayerPosition;
    public string m_SceneName;

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerInfo data = new PlayerInfo();

        data.playerPositionX = GameController.instance.player.transform.position.x;
        data.playerPositionY = GameController.instance.player.transform.position.y;
        GameController.instance.SaveLastPlayerPosition();

        data.SceneName = SceneManager.GetActiveScene().name;
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

            m_PlayerPosition = new Vector3(data.playerPositionX, data.playerPositionY, 0);
            m_SceneName = data.SceneName;
            GameController.instance.LoadLastPlayerPosition(m_PlayerPosition);
            file.Close();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

            PlayerInfo data = new PlayerInfo();

            data.playerPositionX = GameController.instance.player.transform.position.x;
            data.playerPositionY = GameController.instance.player.transform.position.y;
            GameController.instance.SaveLastPlayerPosition();

            data.SceneName = SceneManager.GetActiveScene().name;
            bf.Serialize(file, data);
            file.Close();


        }
    }
}

[System.Serializable]
class PlayerInfo
{
    public float playerPositionX;
    public float playerPositionY;
    public string SceneName;
}

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
    public string m_Difficulty;
    public bool m_LoadGame;
}
using UnityEngine;

[CreateAssetMenu(menuName = "SaveSystemSO")]
public class SaveSystemSO : ScriptableObject
{
    public Vector3 m_PlayerPosition;
    public string m_SceneName;
    public string m_Difficulty;
    public bool m_LoadGame;
}
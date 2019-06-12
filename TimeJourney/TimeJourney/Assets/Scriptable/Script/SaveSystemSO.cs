using UnityEngine;

[CreateAssetMenu(menuName = "SaveSystemSO")]
public class SaveSystemSO : ScriptableObject
{
    public float m_PlayerPositionX;
    public float m_PlayerPositionY;
    public string m_SceneName;
    public string m_Difficulty;
    public bool m_LoadGame;
}
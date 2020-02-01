using UnityEngine;

public class RevivePlayer : MonoBehaviour
{
    /// <summary>
    /// Revive Player
    /// </summary>
    public void Revive()
    {
        LoadPosition();
    }

    /// <summary>
    /// Load Position
    /// </summary>
    public void LoadPosition()
    {
        // set player position
        GameController.instance.player.transform.position = new Vector3(GameController.instance.saveSystemSO.m_PlayerPositionX,
                                                            GameController.instance.saveSystemSO.m_PlayerPositionY,
                                                            0);
        //enable player
        GameController.instance.player.SetActive(true);
    }


}

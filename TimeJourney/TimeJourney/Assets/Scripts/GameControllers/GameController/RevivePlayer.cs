using UnityEngine;

public class RevivePlayer : MonoBehaviour
{
    public void Revive()
    {
        LoadPosition();
    }

    public void LoadPosition()
    {
        GameController.instance.player.transform.position = new Vector3(GameController.instance.saveSystemSO.m_PlayerPositionX,
                                                            GameController.instance.saveSystemSO.m_PlayerPositionY,
                                                            0);
        GameController.instance.player.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePlayer : MonoBehaviour
{
    public void Revive()
    {
        LoadPosition();
    }

    public void LoadPosition()
    {
        GameController.instance.player.transform.position = GameController.instance.saveSystemSO.m_PlayerPosition;
        GameController.instance.player.SetActive(true);
    }


}

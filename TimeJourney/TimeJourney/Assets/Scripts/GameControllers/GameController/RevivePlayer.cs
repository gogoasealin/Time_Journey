using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePlayer : MonoBehaviour
{
    public Vector3 m_LastSavedPosition;

    public void Revive()
    {
        LoadPosition();
    }

    public void LoadPosition()
    {

        GameController.instance.player.transform.position = m_LastSavedPosition;
        GameController.instance.player.SetActive(true);
    }


}

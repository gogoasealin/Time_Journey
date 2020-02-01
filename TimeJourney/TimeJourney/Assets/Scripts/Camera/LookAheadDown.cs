using Cinemachine;
using UnityEngine;

public class LookAheadDown : MonoBehaviour
{
    // reference to the cinemachine 
    CinemachineFramingTransposer cvc;

    /// <summary>
    /// MonoBehaviour Awake function
    /// </summary>
    private void Awake()
    {
        cvc = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (cvc.m_ScreenY > 0.2f)
            {
                cvc.m_ScreenY -= 0.01f;
            }
        }
        else if (cvc.m_ScreenY < 0.5f)
        {
            cvc.m_ScreenY += 0.01f;
        }
        else
        {
            cvc.m_ScreenY = 0.5f;
        }
    }
}

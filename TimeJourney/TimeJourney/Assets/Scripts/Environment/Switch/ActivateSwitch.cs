using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSwitch : MonoBehaviour
{
    public GameObject platformToMove;
    public bool state;
    private SpriteRenderer sr;

    public Sprite state1;
    public Sprite state2;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        GetComponent<MovePlatform>().m_GoToNextPosition = state;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Shot"))
        {
            SwitchState();
            platformToMove.GetComponent<MovePlatform>().enabled = true;
            platformToMove.GetComponent<MovePlatform>().m_GoToNextPosition = state;
        }
    }

    private void SwitchState()
    {
        state = !state;

        state = true ? sr.sprite = state1 : sr.sprite = state2;
    }


}

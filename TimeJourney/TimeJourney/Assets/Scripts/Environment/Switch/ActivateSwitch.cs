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
        platformToMove.GetComponent<MovePlatform>().m_GoToNextPosition = state;
        platformToMove.GetComponent<MovePlatform>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Shot"))
        {
            SwitchState();
            platformToMove.GetComponent<MovePlatform>().enabled = true;
            platformToMove.GetComponent<MovePlatform>().m_GoToNextPosition = state;
            other.gameObject.SetActive(false);
        }
    }

    private void SwitchState()
    {
        state = !state;

        if(sr.sprite == state1)
        {
            sr.sprite = state2;
        }
        else
        {
            sr.sprite = state1;
        }
    }

}

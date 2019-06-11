using UnityEngine;

public class MultiPlatformSwitch : MonoBehaviour
{
    public GameObject[] platformToMove;
    private SpriteRenderer sr;

    public Sprite state1;
    public Sprite state2;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shot"))
        {
            SwitchState();
            for (int i = 0; i < platformToMove.Length; i++)
            {
                platformToMove[i].GetComponent<MovePlatform>().m_GoToNextPosition = !platformToMove[i].GetComponent<MovePlatform>().m_GoToNextPosition;
                platformToMove[i].GetComponent<MovePlatform>().enabled = true;
            }
            other.gameObject.SetActive(false);
        }
    }

    private void SwitchState()
    {
        if (sr.sprite == state1)
        {
            sr.sprite = state2;
        }
        else
        {
            sr.sprite = state1;
        }
    }

}

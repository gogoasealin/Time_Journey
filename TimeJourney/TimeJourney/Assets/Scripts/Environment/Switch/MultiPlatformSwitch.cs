using UnityEngine;

public class MultiPlatformSwitch : MonoBehaviour
{
    // reference to platforms to move
    public GameObject[] platformToMove;

    // reference to sprite renderer
    private SpriteRenderer sr;

    // reference to state1 sprite
    public Sprite state1;

    // reference to state2 sprite
    public Sprite state2;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Handle the trigger collision enter between this gameobject and another one
    /// </summary>
    /// <param name="other">the Gameobject that is colliding with this</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the other gameobject has tag Shot 
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

    /// <summary>
    /// SwitchState
    /// </summary>
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

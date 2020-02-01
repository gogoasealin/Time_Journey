using UnityEngine;

public class ActivateSwitch : MonoBehaviour
{
    // reference to platform to move
    public GameObject platformToMove;

    // state status
    public bool state;

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
        platformToMove.GetComponent<MovePlatform>().m_GoToNextPosition = state;
        platformToMove.GetComponent<MovePlatform>().enabled = false;
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
            platformToMove.GetComponent<MovePlatform>().m_GoToNextPosition = state;
            platformToMove.GetComponent<MovePlatform>().enabled = true;
            other.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// SwitchState
    /// </summary>
    private void SwitchState()
    {
        state = !state;

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

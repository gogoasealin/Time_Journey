using UnityEngine;

public class MultiSwitchActivator : MonoBehaviour
{
    //state
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
            GetComponentInParent<MultiSwitchManager>().UpdateStateOfSwitch(name);
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

using UnityEngine;

public class MultiSwitchManager : MonoBehaviour
{
    // reference to object to activate
    public GameObject objectToActivate;

    //reference to object to switches
    public GameObject[] switches;

    //reference to sprite for switchoff state
    public Sprite switchOff;

    //reference to sprite for switchs state
    private bool[] switchesStates;

    //time to be alive
    public float timeToBeAlive = 5;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        switchesStates = new bool[switches.Length];
    }

    /// <summary>
    /// Update state of switch
    /// </summary>
    /// <param name="name"></param>
    public void UpdateStateOfSwitch(string name)
    {
        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].name.Equals(name))
            {
                SetSwitchState(i);
            }
        }
    }

    /// <summary>
    /// Set switch state
    /// </summary>
    /// <param name="number"></param>
    public void SetSwitchState(int number)
    {
        switchesStates[number] = !switchesStates[number];

        if (CheckSwitches())
        {
            ActivateObject();
        }
    }

    /// <summary>
    /// Check switches
    /// </summary>
    /// <returns></returns>
    public bool CheckSwitches()
    {
        for (int i = 0; i < switchesStates.Length; i++)
        {
            if (!switchesStates[i])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Activate object
    /// </summary>
    public void ActivateObject()
    {
        objectToActivate.SetActive(true);
        Invoke("TimesUP", timeToBeAlive);
    }

    /// <summary>
    /// Reset
    /// </summary>
    public void Reset()
    {
        for (int i = 0; i < switches.Length; i++)
        {
            switches[i].GetComponent<SpriteRenderer>().sprite = switchOff;
        }

        for (int i = 0; i < switchesStates.Length; i++)
        {
            switchesStates[i] = false;
        }
    }

    /// <summary>
    /// Times up
    /// </summary>
    public void TimesUP()
    {
        Reset();
        objectToActivate.SetActive(false);
    }


}

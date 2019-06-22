using UnityEngine;

public class MultiSwitchManager : MonoBehaviour
{

    public GameObject objectToActivate;
    public GameObject[] switches;
    public Sprite switchOff;
    private bool[] switchesStates;

    public float timeToBeAlive = 5;

    private void Start()
    {
        switchesStates = new bool[switches.Length];
    }

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

    public void SetSwitchState(int number)
    {
        switchesStates[number] = !switchesStates[number];

        if (CheckSwitches())
        {
            ActivateObject();
        }
    }

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

    public void ActivateObject()
    {
        objectToActivate.SetActive(true);
        Invoke("TimesUP", timeToBeAlive);
    }

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

    public void TimesUP()
    {
        Reset();
        objectToActivate.SetActive(false);
    }


}

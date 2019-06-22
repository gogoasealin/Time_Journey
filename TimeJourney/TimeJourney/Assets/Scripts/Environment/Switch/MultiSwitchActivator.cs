using UnityEngine;

public class MultiSwitchActivator : MonoBehaviour
{
    public bool state;
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
            GetComponentInParent<MultiSwitchManager>().UpdateStateOfSwitch(name);
            other.gameObject.SetActive(false);
        }
    }

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
